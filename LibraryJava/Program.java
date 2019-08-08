
import java.io.IOException;

public class Program {
  public static void main(String[] args) throws IOException {
    Library library = Library.getInstance();
    library.bankBooks.put(1, new Book("Война и мир", "Л.Н.Толстой", 1867));
    library.bankBooks.put(2, new Book("Преступление и наказание", "Ф.М.Достоевский", 1866));
    library.bankBooks.put(3, new Book("Евгений Онегин", "А.С.Пушкин", 1831));
    System.out.println("Добро пожаловать в библиотеку.");
    while (true) {
      System.out.println(
          "Если Вы хотите просмотреть списко книг, пожалуйста, нажмите 1.\n" +
              "Если Вы хотите внести новую книгу, пожалуйста, нажмите 2.\n" +
              "Если Вы хотите удалить книгу, пожалуйста, нажмите 3.\n" +
              "Если Вы хотите взять книгу, пожалуйста, нажимте 4.\n" +
              "Если Вы хотите просмотреть списко используемых книг, пожалуйста, нажимте 5.\n" +
              "Если Вы хотите выйти из программы, пожалуйста, нажмите 6.");
      int r = Integer.parseInt(library.reader.readLine());
      if (r == 1) {
        library.showBooks();
      } else if (r == 2) {
        library.createBook();
      } else if (r == 3) {
        library.removeBook();
      } else if (r == 4) {
        library.takeBook();
      } else if (r == 5) {
        library.showTakenBooks();
      } else if (r == 6) {
        break;
      }
    }
  }
}





