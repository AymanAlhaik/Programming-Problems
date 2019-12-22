import 'dart:core';
import 'dart:io';
void main(List<String> args) {
  print('enter your string to print it as pyramid of Strings');
  String pattern = stdin.readLineSync();
  for (var i = 0; i < pattern.length; i++) {
    String currentLine = calcPattern(pattern.substring(0, i));
    String current = addIdenting(currentLine, pattern.length-i);
    print(current);
  }
}
String calcPattern(String str) {
  if (str == null) return '';
  int strLength = str.length;
  if (strLength == 1) {
    return str;
  }
  String newString = str;
  for (var i = strLength - 2; i >= 0; i--) {
    newString += str[i];
  }
  return newString;
}
String addIdenting(String str, int spacesNum) {
  String spaces = ' ' * spacesNum;
  String indentedString = spaces + str;
  return indentedString;
}
