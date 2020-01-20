using Microsoft.EntityFrameworkCore.Migrations;

namespace BookCatalogue.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Authors (Name) Values ('Alexandre Dumas')");
            migrationBuilder.Sql("INSERT INTO Authors (Name) Values ('Jules Verne')");
            migrationBuilder.Sql("INSERT INTO Authors (Name) Values ('Konstantine Gamsakhurdia')");

            migrationBuilder.Sql("INSERT INTO BookCategories (Name) Values ('Action and adventure')");
            migrationBuilder.Sql("INSERT INTO BookCategories (Name) Values ('Romance')");

            migrationBuilder.Sql(@"INSERT INTO Books (AuthorId, CategoryId, Title)
                                    Values ((SELECT ID FROM Authors WHERE Name = 'Alexandre Dumas'),
                                            (SELECT ID FROM BookCategories WHERE Name = 'Action and adventure'),
                                            'The Three Musketeers')"
            );
            migrationBuilder.Sql(@"INSERT INTO Books (AuthorId, CategoryId, Title)
                                    Values ((SELECT ID FROM Authors WHERE Name = 'Alexandre Dumas'),
                                    (SELECT ID FROM BookCategories WHERE Name = 'Action and adventure'),
                                    'The Count of Monte Cristo')"
            );
            migrationBuilder.Sql(@"INSERT INTO Books (AuthorId, CategoryId, Title)
                                    Values ((SELECT ID FROM Authors WHERE Name = 'Jules Verne'),
                                    (SELECT ID FROM BookCategories WHERE Name = 'Action and adventure'),
                                    'The Mysterious Island')"
            );
            migrationBuilder.Sql(@"INSERT INTO Books (AuthorId, CategoryId, Title)
                                    Values ((SELECT ID FROM Authors WHERE Name = 'Jules Verne'),
                                    (SELECT ID FROM BookCategories WHERE Name = 'Action and adventure'),
                                    'Around the World in Eighty Days')"
            );
            migrationBuilder.Sql(@"INSERT INTO Books (AuthorId, CategoryId, Title)
                                    Values ((SELECT ID FROM Authors WHERE Name = 'Konstantine Gamsakhurdia'),
                                    (SELECT ID FROM BookCategories WHERE Name = 'Romance'),
                                    'Stealing the Moon')"
            );
            migrationBuilder.Sql(@"INSERT INTO Books (AuthorId, CategoryId, Title)
                                    Values ((SELECT ID FROM Authors WHERE Name = 'Konstantine Gamsakhurdia'),
                                    (SELECT ID FROM BookCategories WHERE Name = 'Romance'),
                                    'The Right Hand of the Grand Master')"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Books");
        }
    }
}
