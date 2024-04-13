import xmltodict 
import yaml 
# Converts XML to YAML
xml_file = open("C:\TRITON\XML\Biomes.XML")
xml_string = xml_file.read()
python_dict=xmltodict.parse(xml_string)
file=open("C:\TRITON\YAML\Biome.yaml", "w")
yaml.dump(python_dict, file)
file.close()