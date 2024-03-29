
/*
  write a function that rotates a list by a given number of elements k
  [1, 2, 3, 4] and k=2 --> [3, 4, 1, 2]
                       k=3 --> [4, 1, 2, 3]
                       k=4 --> [1, 2, 3, 4]
 */


main(List<String> args) {
  List<int> list = [1, 2, 3, 4, 5];
  rotateList(list, 0);
  print(list);
}

void rotateList(List<int> list, int k) {
  if (k > list.length || k < 0) {
    throw new Exception("k must be from [0, list.length)");
  }
  //appending the elements at the end of the list
  for (var i = 0; i < k; i++) {
    list.add(list[i]);
  }
  //removing added elements from the begining of the list
  for (var i = 0; i < k; i++) {
    list.removeAt(0);
  }
}
