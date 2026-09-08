using System.Text.Json;
using MyDogamDesktop.Models;

namespace MyDogamDesktop.Services
{
    public class JsonParserService
    {
        public List<ParsedItem> ParseCollectionJson(string jsonText)
        {
            // JSON 텍스트를 파싱하고, RootElement가 배열인지, 객체인지 판단해 배열의 시작점부터 itemsArray에 할당
            using JsonDocument doc = JsonDocument.Parse(jsonText); //jsonText를 JsonDocument로 파싱, RootElement를 가져옴
            JsonElement root = doc.RootElement;

            JsonElement itemsArray;
            if (root.ValueKind == JsonValueKind.Array) // RootElement가 배열인 경우
            {
                itemsArray = root;
            }
            else if (root.ValueKind == JsonValueKind.Object) // RootElement가 객체인 경우
            {
                JsonElement? found = null;
                foreach (JsonProperty prop in root.EnumerateObject()) //RootElement의 객체 내부를 반복, prop값으로 가져옴
                {
                    if (prop.Value.ValueKind == JsonValueKind.Array) // prop의 값이 배열인 경우
                    {
                        found = prop.Value;
                        break;
                    }
                }

                if (found == null) // prop의 값에 배열이 한번이라도 없었던 경우
                {
                    throw new Exception("JSON 안에서 배열 데이터를 찾을 수 없습니다.");
                }
                itemsArray = found.Value; // prop의 값이 배열인 경우, itemsArray에 할당
            }
            else // RootElement가 배열도 객체도 아닌 경우
            {
                throw new Exception("지원하지 않는 JSON 형식입니다.");
            }

            // itemsArray 배열의 각 원소를 ParsedItem 객체로 변환하고, result 리스트에 저장
            List<ParsedItem> result = new List<ParsedItem>();
            foreach (JsonElement element in itemsArray.EnumerateArray()) // itemsArray 배열의 각 원소를 반복
            {
                if (!element.TryGetProperty("id", out JsonElement idProp) ||
                    !element.TryGetProperty("name", out JsonElement nameProp)) // element에 'id', 'name' 속성이 하나라도 없는 경우
                {
                    continue; // 다음 원소로 넘어가기
                }

                var item = new ParsedItem
                {
                    Id = idProp.GetString() ?? "",
                    Name = nameProp.GetString() ?? "",

                }; // item 객체를 생성하고, 'id', 'name' 속성 값 할당

                foreach (JsonProperty prop in element.EnumerateObject()) // element의 모든 속성을 반복
                {
                    item.Metadata[prop.Name] = prop.Value.ToString(); // item의 Metadata 딕셔너리에 속성 이름 (key)와 값 (value)을 저장
                }

                result.Add(item); // result 리스트에 item 객체 추가
            }

            if (result.Count == 0) { // result 리스트가 비어있는 경우
                throw new Exception("'id'와 'name'을 가진 항목이 없습니다.");
            }

            return result;
        }
    }
}
