using System;
using System.Diagnostics;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using static System.Console;



namespace ConsoleApp1
{
    
   
    class User 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;}
        [BsonElement("name")]
        [BsonIgnoreIfNull]
    public string Name { get; set;}
    
    [BsonElement("artist")]
    [BsonIgnoreIfNull]
    public string Artist { get; set; }
    
    [BsonElement("country")]
    [BsonIgnoreIfNull]
    public string Country { get; set; }
    
    [BsonElement("date_made")]
    [BsonIgnoreIfNull]
    [BsonDefaultValue("Неустановлена")]
    public string Date_Made { get; set; }
    
    [BsonElement("length")]
    [BsonIgnoreIfNull]
    public string Length { get; set; }
    
    [BsonElement("style")]
    [BsonIgnoreIfNull]
    public string Style { get; set; }
    
    
    }
    class Program
    {
        public static void UserInterface()
        {
            WriteLine("База данных");
            WriteLine("Музыкальная коллекция");
            WriteLine("-------------------------------------------------------------------------------------");
            WriteLine("Нажмите:");
            WriteLine("1 - для просмотра всей базы данных");
            WriteLine("2 - для добавления данных в БД");
            WriteLine("3 - для редактирования данных в БД \n\n\n");

        }
        
        static void Main(string[] args)
        {
            string connetction_string = "mongodb://localhost";
            var db = new MongoClient(connetction_string);
            var dbList = db.ListDatabases().ToList();
            var test = db.GetDatabase("admin");
            var users = test.GetCollection<User>("admin");
             var filter = new BsonDocument();
            var documents = users.Find(filter).ToList();

            UserInterface();
         
           string act = ReadLine();
           
          
           switch (act)
           {
               case "1":
               {
                   foreach (var user in documents)

                   {
                       Write($"Имя: {user.Name} ");
                       Write($"Исполнитель: {user.Artist} ");
                       Write($"Дата выхода: - {user.Date_Made} ");
                       Write($"Стиль: {user.Style} ");
                       WriteLine($"Страна: {user.Country} ");
                   }

                   break;
               }
          
               case "2":
               {
                   /* var temp  = new User
                            {
                                Name = "Jack",
                                    Artist = "21"
                                  };
                            users.InsertOne(temp);
                            */
                   break;
               }

             default: 
               break;

           }
        }
    }
}
