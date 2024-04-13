@echo off
setlocal enabledelayedexpansion

set input_file=input.txt
set output_file=output.yaml

echo items: > %output_file%

for /f "tokens=*" %%a in (%input_file%) do (
   for %%b in (%%a) do (
      set name=%%b
      echo   - Animals: "Empty"  >> %output_file%
      echo     Biome.Name: !name! >> %output_file%
      echo     Crops: "Empty" >> %output_file%
      echo     Level: "Empty" >> %output_file%
      echo     Metals:  "Empty" >> %output_file%
      echo     Plants:  "Empty" >> %output_file%
      echo     Woods: "Empty" >> %output_file%
   )
)

echo Intake complete. Output saved to %output_file%. Please convert to XML with ytx.py to see in TRITON.
pause