namespace CrudTests
{
    public class UnitTest1 : Mock
    {
        [Fact]
        public async void AddAndUpdate()
        {
            var hotel = await CreateAndSaveHotel();
            Assert.NotNull( hotel);
            hotel.Name = "updating test";
            var updatedHotel = await UpdateAndSaveHotel(hotel);
            Assert.Equal("updating test", updatedHotel.Name); 
        }

    }
}