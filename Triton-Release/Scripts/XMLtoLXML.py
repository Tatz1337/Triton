import os
import lxml.etree as et 

# load XML and XSL files
xml = et.parse("C:\TRITON\XML\Resources.XML")
xsl = et.parse("C:\TRITON\XSLT\Resources.xsl")

# xfr source 
transform = et.XSLT(xsl)
result = transform(xml)

# print 
print(result)

# save 
with open("C:\TRITON\XML\CleanedResources.XML", "wb") as f:
    f.write(result)