import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

class Library {
  private static Library instance;

  private Library() {
  }

  static Library getInstance() {
    if (instance == null)
      instance = new Library();
    return instance;
  }

  BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
  HashMap<Integer, Book> bankBooks = new HashMap<>();
  HashMap<Integer, Book> takenBooks = new HashMap<>();

  void showBooks() {
    for (Map.Entry entry : bankBooks.entrySet()) {
      System.out.println(entry);
    }
  }

  void createBook() throws IOException {
    Book book = new Book("", "", 0);
    int Id;
    while (true) {
      System.out.println("Введите id.");
      int id = Integer.parseInt(reader.readLine());
      Set<Integer> keys = bankBooks.keySet();
      if (keys.contains(id)) {
        System.out.println("Книга с таким id уже существует, пожалуйста, введите другой id.");
      } else {
        Id = id;
        break;
      }
    }

    System.out.println("Введите название книги, например: Война и мир");
    String name = reader.readLine();
    book.setName(name);
    System.out.println("Введите автора книги, например: А.С.Пушкин");
    String author = reader.readLine();
    book.setAuthor(author);
    System.out.println("Введите год выпуска книги, например: 1867");
    int year = Integer.parseInt(reader.readLine());
    book.setYear(year);
    bankBooks.put(Id, book);
    for (Map.Entry entry : bankBooks.entrySet()) {
      System.out.println(entry);
    }
  }

  void takeBook() throws IOException {
    while (true) {
      showBooks();
      System.out.println("Введите id книги, которую хотите взять.");
      int id = Integer.parseInt(reader.readLine());
      for (int i = 0; i <= takenBooks.size(); i++) {
        Set<Integer> keys = takenBooks.keySet();
        if (keys.contains(id)) {
          System.out.println("Книга, под введенным Вами id уже используется.");
          break;
        }
      }
      for (int i = 0; i <= bankBooks.size(); i++) {
        Set<Integer> keys = bankBooks.keySet();
        if (keys.contains(id)) {
          takenBooks.put(id, bankBooks.get(i));
        }
      }
      if (takenBooks.containsKey(id)) {
        break;
      } else {
        System.out.println("книга с указанным id не существует.");
      }
    }
  }

  void showTakenBooks() {
    for (Map.Entry entry : takenBooks.entrySet()) {
      System.out.println(entry);
    }
  }

  void removeBook() throws IOException {
    while (true) {
      System.out.println("Введите id книги.");
      int id = Integer.parseInt(reader.readLine());
      Set<Integer> keys = bankBooks.keySet();
      if (!keys.contains(id)) {
        System.out.println("Введенное id не существует.");
      } else {
        bankBooks.remove(id);
        break;
      }
    }
  }
}
