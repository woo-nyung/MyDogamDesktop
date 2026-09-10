using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using MyDogamDesktop.Data;
using MyDogamDesktop.Models;
using System.Text.Json;

namespace MyDogamDesktop.Services
{
    public class CollectionService
    {
        public async Task<List<Collection>> GetAllCollectionsAsync() {
            using var db = new AppDbContext();
            return await db.Collections.OrderByDescending(c => c.CreatedAt).ToListAsync(); // 최신순으로 정렬
        }
        public async Task<List<CollectionItem>> GetItemsByCollectionIdAsync(int collectionId) {
            using var db = new AppDbContext();
            return await db.Items.Where(i => i.CollectionId == collectionId).ToListAsync();
        }
        public async Task<int> CreateCollectionFromItemsAsync(string name, string fileName, List<ParsedItem> items)
        {
            // DB tabl 생성
            using var db = new AppDbContext();

            // 프로퍼티 추가해서 Collection 객체 생성
            var collection = new Collection
            {
                Name = name,
                FileName = fileName,
                TotalItems = items.Count,
                CreatedAt = DateTime.Now,
            };
            db.Collections.Add(collection); // db에 추가
            await db.SaveChangesAsync(); // 비동기 => 여기서 값을 받을 때까지 대기, 다른 동작 수행

            // items 리스트 기준으로 매핑해서 CollectionItem 리스트 생성
            var collectionItems = items.Select(item => new CollectionItem
            {
                CollectionId = collection.Id,
                ItemId = item.Id,
                Name = item.Name,
                Count = 0,
                MetadataJson = JsonSerializer.Serialize(item.Metadata) // item.Metadata를 직렬화
            }).ToList();

            db.Items.AddRange(collectionItems); // collectionItems 리스트를 db.Items에 추가
            await db.SaveChangesAsync(); // 비동기 => 여기서 값을 받을 때까지 대기, 다른 동작 수행

            return collection.Id;
        }
        public async Task DeleteCollectionAsync(int collectionId)
        {
            using var db = new AppDbContext();

            // 컬렉션 내부 아이템 먼저 삭제
            var items = db.Items.Where(i => i.CollectionId == collectionId);
            db.Items.RemoveRange(items);

            // 컬렉션 삭제
            var collection = await db.Collections.FindAsync(collectionId);
            if (collection != null) {
                db.Collections.Remove(collection);
            }

            await db.SaveChangesAsync();
        }

        public async Task UpdateItemCountAsync(int itemId, int newCount)
        {
            using var db = new AppDbContext();
            var item = await db.Items.FindAsync(itemId);
            if (item != null)
            {
                item.Count = newCount;
                await db.SaveChangesAsync();
            }
        }
    }
}
