namespace Task1.Models
{
        public class City
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int StateId { get; set; }

            internal static bool Contains(string v)
            {
                throw new NotImplementedException();
            }
        }

        public class State
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

  
}
