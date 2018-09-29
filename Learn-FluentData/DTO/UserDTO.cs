namespace Learn_FluentData.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"User [ ID:{this.Id} Name:{this.Name} Age:{this.Age} ]";
        }
    }
}
