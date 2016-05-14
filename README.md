# xml-sql-case-converter
massive conversion sql code from uppercase to lower and vice-versa in xml files (used to correct snippets in apexsql complete tool).
don't judge me too hard, it is mostly sample project to test github. but project is real, sometimes this tool can be useful.
how it works:
1. button "folders" - select one or many files, they will be displayed in left list.
2. select from left list one or many (using "shift") files for conversion.
3. set target node name in textbox, now it has default value "Text".
4. push button "C > c" (upper to lower) or "c > C" (lower to upper), all text inside defined nodes will have changed letter case, except hint N'...' before unicode strings and macros keywods like %CARET%.
5. processed files will be placed in new "/xcn" subfolder with same names and displayed in right list.
