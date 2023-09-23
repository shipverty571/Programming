using NoteApp.Domain.Entity;

namespace NoteApp.TestValues
{
    public static class TestData
    {
        public static List<NoteEntity> Notes = new List<NoteEntity>
            {
                new NoteEntity
                {
                    Category = Domain.Enums.Category.Work,
                    Name = "NOTE 1",
                    Description = "DESC 1",
                },
                new NoteEntity
                {
                    Category = Domain.Enums.Category.Home,
                    Name = "NOTE 2",
                    Description = "DESC 2",
                },
                new NoteEntity
                {
                    Category = Domain.Enums.Category.Documents,
                    Name = "NOTE 3",
                    Description = "DESC 3",
                }
            };
    }
}
