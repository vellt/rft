import 'dart:async';
import 'dart:convert';
import 'package:get/get.dart';
import 'package:rtf_ui/models/exam.dart';
import 'package:http/http.dart' as http;

class ExamListViewController extends GetxController {
  bool isLoaded = false;

  List<Exam> exams = [];

  // https://remainder-glasgow-reality-partners.trycloudflare.com/api/exams --> igeiglenes link,
  // a cloudflare tunnel által generált link, hozzá van csatolva a localhost portja
  //
  // A flutter nem tud kezelni localhostot közvetlenül, igy emiatt tesztelni/elérni
  // az API-t csak külső webcímről tehetem meg, szerverre emiatt nem akartam felrakni.
  // Továbbá a localhostom https-es, és mivel saját certificat-et használok ténylegesen
  // használni az URL-t akkor lehet ha a projektet, legalább is weben "--disable-web-security" tesszük meg
  // viszont képeket csatolni fogok a nézetről, hogy futtatva hogyan is néz ki.
  Future getExamList() async {
    var response = await http.get(Uri.parse(
        " https://remainder-glasgow-reality-partners.trycloudflare.com/api/exams"));

    if (response.statusCode == 200) {
      final List<dynamic> examJsonList = json.decode(response.body);
      exams = examJsonList.map((json) => Exam.fromJson(json)).toList();
    }

    this.isLoaded = true;
    update();
  }

  @override
  void onInit() {
    super.onInit();
    getExamList();
  }
}
