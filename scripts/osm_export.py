import numpy as np
import overpy
import json

print("Search for a specific city / suburb at https://www.wikidata.org/ and copy the WikiData ID (usually starting "
      "with a 'Q') (e.g. Q835440 for the University of Constance). This script will then generate a basic json graph "
      "file from data gathered from the OSM-API.")

api = overpy.Overpass()

r0 = api.query("""
area["wikidata"=""" + input("WikiData ID: ") + """]->.a;
(node(area.a); way(area.a););
out center;
""")

cosphi0 = float(np.math.cos(abs(r0.nodes[0].lat)))

nodes = {}
edges = []

minX, minY, maxX, maxY = None, None, None, None

for node in r0.nodes:
    x = float(node.lon) * cosphi0
    y = float(node.lat)
    if minX is None:
        minX = x
    elif minX > x:
        minX = x
    if minY is None:
        minY = y
    elif minY > y:
        minY = y
    if maxX is None:
        maxX = x
    elif maxX < x:
        maxX = x
    if maxY is None:
        maxY = y
    elif maxY < y:
        maxY = y
    nodes[node.id] = {
        'x': x,
        'y': y,
        'metadata': node.tags
    }

if maxX - minX > maxY - minY:
    xNorm, yNorm = 1.0, (maxY - minY) / (maxX - minX)
else:
    xNorm, yNorm = (maxX - minX) / (maxY - minY), 1.0

counter = 0

for key, node in nodes.items():
    counter += 1
    oldX = node['x']
    oldY = node['y']
    node['x'] = xNorm * (oldX - minX) / (maxX - minX)
    node['y'] = yNorm * (oldY - minY) / (maxY - minY)


for way in r0.ways:
    wayNodes = way.get_nodes(resolve_missing=True)
    for i in [0, len(wayNodes) - 2]:
        if (wayNodes[i].id in nodes) & (wayNodes[i + 1].id in nodes):
            edges.append({
                'source': wayNodes[i].id,
                'target': wayNodes[i + 1].id,
                'directed': False,
                'metadata': []
            })

output = json.dumps({
    'graph': {
        'directed': False,
        'metadata': [],
        'nodes': nodes,
        'edges': edges
    }
}, indent=2)

f = open("output.json", "w")
f.write(output)
f.close()
