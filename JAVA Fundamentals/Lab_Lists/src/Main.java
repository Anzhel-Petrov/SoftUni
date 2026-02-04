import java.util.List;

public class Main {
    public static void main(String[] args) {

        //List<String> list1 = new ArrayList<>();
        var list2 = List.of(1,2,3,4,5,6,7,8);
        var foor = list2.stream()
                .filter(n -> n % 2 == 0)
                .map(n -> n * 10)
                .toList();

        System.out.println(foor);
        //foor.forEach(System.out::println);
    }
}