
# TRITON - Worldbuilding Tool

Triton is a collection of things I've been working on, 95% in VB.NET.

The most prominent feature of the tool is acting as a sort of dictionary for topics that a friend and I use to worldbuild. 

Currently, Triton consists of: 
* Biome Manager
* Resource Manager
* Fleet Manager
* Simple GDP Calculator
* Council Voting Simulator
* Morse Code to English Translator (with audible beep option)
* Map Generator (Credit: @BoopBoops on VBForums) *Will be altering code in future, however currently it is unchanged.

Obviously, nothing revolutionary. However, this project was sparked from gaps in worldbuilding programs I wanted to fill for myself. The current options are fairly niche, but I believe the source code allows for a great amount of scalability and flex to the content stored in the suite. 


### Documentation
There is no "presentable" documentation yet, but it is in progress! 

### How data is saved and read (and other options)
Data, by default, is parsed from XML here. There are some optional Python scripts in "/scripts/ for converting the XML files to YAML, and vice versa. 

YAMLDotNet is current an import in the software, but is not utilized. It will be implemented in the future and a toggle for choosing between saving to XML or YAML will be added. 

There is also a Batch script included which allows for mass ingress of information from text files. For example, if you had a list of 1000 types of wood and pasted it into "input.txt" and ran the script, it would read each line from it and write it to the "output.yaml" file. The YAML to XML script can successfully convert the output into a program-readable XML. To actually *add* them to the main XML, the best method I have found is to firstly convert the XML to YAML, then copy the converted output and paste it into the YAML file then convert it to XML. 

Ultimately this is just a fun little passion project for me, but I am always welcoming to suggestions or requests!






