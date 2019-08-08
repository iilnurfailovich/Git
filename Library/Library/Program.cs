using System;



namespace Library
{
    public enum ActionType 
    {
        ShowBooks = 1,
        CreateBook,
        RemoveBook,
        TakeBook,
        ShowTakenBooks,
        ReturnBook,
        ToExitTheProgramme
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new LibrariDbContext())
            {
                var libraryService = LibraryService.GetInstance(context);
                Console.WriteLine("Добро пожаловать в библиотеку!");
                while (true)
                {
                    Console.WriteLine(
                        "Если Вы хотите просмотреть списко книг, пожалуйста, нажмите 1.\n" +
                        "Если Вы хотите внести новую книгу, пожалуйста, нажмите 2.\n" +
                        "Если Вы хотите удалить книгу, пожалуйста, нажмите 3.\n" +
                        "Если Вы хотите взять книгу, пожалуйста, нажимте 4.\n" +
                        "Если Вы хотите просмотреть списко используемых книг, пожалуйста, нажимте 5.\n" +
                        "Если Вы хотите вернуть книгу, пожалуйста, нажимте 6.\n" +
                        "Если Вы хотите выйти из программы, пожалуйста, нажмите 7.");
                    var typeAction = (ActionType)Convert.ToInt32(Console.ReadLine());

                    switch (typeAction)
                    {
                        case ActionType.ShowBooks:
                            libraryService.ShowBooks(false);
                            break;
                        case ActionType.CreateBook:
                            libraryService.CreateBook();
                            break;
                        case ActionType.RemoveBook:
                            libraryService.RemoveBook();
                            break;
                        case ActionType.TakeBook:
                            libraryService.TakeBook();
                            break;
                        case ActionType.ShowTakenBooks:
                            libraryService.ShowBooks(true);
                            break;
                        case ActionType.ReturnBook:
                            libraryService.ReturnBook();
                            break;
                        case ActionType.ToExitTheProgramme:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }
    }
}
