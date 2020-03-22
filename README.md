# Pandemic Stopper
Wir sind ein Team aus Informatikstudenten der Unis Aachen und Konstanz.
Viele werden das Spiel „Plague Inc.“ kennen, in welchem der Spieler die Welt mit einer tödlichen Seuche infizieren und die Menschheit so auslöschen muss.
Unser Spiel „Pandemic Stopper“ ist umgekehrt. Hier muss der Spieler die Infizierten so eindämmen, sodass die meisten Menschen gesund bleiben. Beim Beginn des Spiels gibt es genau einen Infizierten – den Patient 0. Dieser steckt dann weitere Spieler an. Die Schwierigkeit dabei: Jeder Mensch hat eine individuelle Inkubationszeit, die von der Norm abweicht und Infizierte werden erst nach der Inkubationszeit als Kranke angezeigt und so für den Spieler sichtbar.
Das Ziel des Spielers soll es sein, möglichst wenig Infizierte zu haben und das öffentliche Leben mit möglichst wenig Straßensperren so gering wie möglich einzuschränken.
Mit unserem Spiel wollen wir für die Allgemeinheit erfahrbar machen, wie schwer es ist, einen Virus vernünftig einzudämmen und gleichzeitig das öffentliche Leben nicht zu stark einzuschränken.
In Zukunft würden wir gerne das Spielfeld automatisch auf jede Stadtkarte der Welt anwenden können, die Benutzeroberfläche verschönern und in die Modelle Forschungsdaten einer beliebigen Infektionskrankheit einfließen lassen.

## Dokumentation des Repository
In Form eines PDF befindet sich im Ordner **Dokumentation** dieses Readme.
Das Programm basiert auf Unity. Es befindet sich im Ordner **WirVsVirus**.
Um automatisch von osm.org das Spielfeld generieren zu können. Befindet sich in **scripts** ein Skript zur Erstellung eines Graphs aus OSM-Daten

###  Das Unity Projekt
Das wichtige Zeugs passiert in **Assets**.

#### Assets
  * **Materials** sind die Materialien, aus denen Sachen bestehen. (ähnlich wie Texturen)
  * **Prefabs** sind die Vorlagen unserer Elemente

    * ##### Unsere Elemente
      * **Node** und **Edge** sind die Knoten und Kanten unseres Graphen, welche als Kreuzungen und Kanten verstanden werden können.
      * **Points** sind die einzelnen "Menschen", also mögliche Infizierte.

  * In **Resources** sind z.B. die Bilder gespeichert.
  * **Scenes** sind Spielfelder.
  * **Scripts** sind unsere Skripte. Sie handlen alle Aktionen.

    * ##### Scripts
      * **Edge** sind die Kanten, also in unserem Fall Straßen. Hier werden auch die Mouse-Events behandelt, sowie die Straßensperrungen.
      * **Generator** und **GeneratorEditor** sollen aus JSON-Dateien, welche von dem Script des Ordners /scripts generiert wurden Nodes und Edges erzeugen.
      * **Line Helper** ist eine Hilfe zum Linien zwischen Nodes zu malen.
      * **Main legt die Parameter für die Infektionskrankheit fest.**
      * **Node** sind die Kreuzungen. Hier werden die anliegenden Kanten für die Punkte zufällig ausgewählt.
      * **Point** sind die einzelnen "Menschen", also mögliche Infizierte. Hier werden die Collisions zwischen den Punkten, also die Infektionen, die Bewegungungen, die Inkubationszeit, etc. gemanagt.

In **Logs**, **Packages** und **ProjectSettings** befinden sich Unity-eigene Dateien.
