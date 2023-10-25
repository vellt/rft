import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';
import 'package:rtf_ui/controllers/exam_list_view_controller.dart';

class ExamListView extends StatelessWidget {
  const ExamListView({super.key});

  @override
  Widget build(BuildContext context) {
    ExamListViewController controller = Get.put(ExamListViewController());
    double screenWidth = MediaQuery.of(context).size.width;
    int maxItemsPerRow;

    if (screenWidth >= 1200) {
      // Tablet vagy nagyobb kijelző
      maxItemsPerRow = 4;
    } else if (screenWidth >= 600) {
      // Tablet vagy nagyobb kijelző
      maxItemsPerRow = 3;
    } else if (screenWidth >= 400) {
      // Mobil kijelző
      maxItemsPerRow = 2;
    } else {
      // Kis kijelző
      maxItemsPerRow = 1;
    }

    return GetBuilder<ExamListViewController>(
        init: controller,
        builder: (_) {
          return Scaffold(
            appBar: AppBar(title: Text("Meghírdetett Vizsgák")),
            drawer: Drawer(),
            body: (!controller.isLoaded)
                ? Container(
                    child: Center(child: CircularProgressIndicator()),
                  )
                : Align(
                    alignment: Alignment.topCenter,
                    child: Padding(
                      padding: const EdgeInsets.only(top: 10),
                      child: Wrap(
                        spacing: 8.0, // Szóköz az elemek között vízszintesen
                        runSpacing: 8.0, // Szóköz az elemek között függőlegesen
                        alignment: WrapAlignment.start,

                        children:
                            List.generate(controller.exams.length, (index) {
                          return Card(
                            child: Container(
                              width: screenWidth / maxItemsPerRow -
                                  20, // 20 az elemek közötti margó miatt
                              padding: EdgeInsets.all(20),
                              child: Column(
                                children: [
                                  Container(
                                    padding: EdgeInsets.all(5),
                                    child: Column(
                                        crossAxisAlignment:
                                            CrossAxisAlignment.start,
                                        children: [
                                          Row(
                                            children: [
                                              Container(
                                                width: screenWidth /
                                                        maxItemsPerRow -
                                                    70,
                                                height: 100,
                                                color: Colors.grey.shade100,
                                                child: Center(
                                                  child: Text(
                                                    controller
                                                        .exams[index].course,
                                                    style:
                                                        TextStyle(fontSize: 23),
                                                  ),
                                                ),
                                              ),
                                            ],
                                          ),
                                          SizedBox(
                                            height: 15,
                                          ),
                                          Text(
                                              'Meghírdette: ${controller.exams[index].makerID}'),
                                          SizedBox(
                                            height: 10,
                                          ),
                                          Text(
                                              'Helyszín: ${controller.exams[index].location}'),
                                        ]),
                                  ),
                                  Container(
                                    width: double.infinity,
                                    padding: EdgeInsets.all(5),
                                    child: CupertinoButton.filled(
                                      padding: EdgeInsets.zero,
                                      child: Text("Jelentkezés"),
                                      onPressed: () {},
                                    ),
                                  )
                                ],
                              ),
                            ),
                          );
                        }),
                      ),
                    ),
                  ),
          );
        });
  }
}
