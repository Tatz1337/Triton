import yaml
from yaml import SafeLoader
import xmltodict
import time
# Converts YAML to XML
yaml_file=open("C:\TRITON\YAML\Resources.yaml", "r")
python_dict = yaml.load(yaml_file, Loader=SafeLoader)
file = open("C:\TRITON\XML\Resources.XML", "w")
xml_string = xmltodict.unparse(python_dict, output=file)
file.close()
yaml_file.close()
time.sleep(50)