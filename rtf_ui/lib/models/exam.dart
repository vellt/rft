class Exam {
  int id;
  int makerID;
  String maker = "";
  DateTime dateTime;
  String course;
  String location;
  Exam({
    required this.id,
    required this.makerID,
    required this.dateTime,
    required this.course,
    required this.location,
  });
  factory Exam.fromJson(Map<String, dynamic> json) {
    return Exam(
      id: json['id'],
      course: json['course'],
      dateTime: DateTime.parse(json['dateTime']),
      location: json['location'],
      makerID: json['makerID'],
    );
  }
}
