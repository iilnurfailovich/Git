public class Book {

  private String name;
  private String author;
  private int year;


  Book( String name, String author, int year) {
    this.name = name;
    this.author = author;
    this.year = year;
  }


  private String getName() { return name; }

  void setName(String name) { this.name = name; }

  private String getAuthor() { return author; }

  void setAuthor(String author) { this.author = author; }

  private int getYear() { return year; }

  void setYear(int year) { this.year = year; }

  public String toString(){
    return "название книги: " + name + " " + ", автор книги: " + author + " " + ", год выпуска книги: " + year + " год.";
  }

  public boolean contains(String id) {
    return true;
  }
}


