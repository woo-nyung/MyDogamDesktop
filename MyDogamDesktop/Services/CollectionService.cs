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
        public async Task<int> CreateCollectionFromItemsAsync(string name, string fileName, List<ParsedItem> items)
        {
            // DB table을 생성한건가?
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
                MetadataJson = JsonSerializer.Serialize(item.Metadata) // 이건 어떤 메소드?
            }).ToList();

            db.Items.AddRange(collectionItems); // AddRange는 어떤 메소드?
            await db.SaveChangesAsync(); // 비동기 => 여기서 값을 받을 때까지 대기, 다른 동작 수행

            return collection.Id;
        }
    }
}
