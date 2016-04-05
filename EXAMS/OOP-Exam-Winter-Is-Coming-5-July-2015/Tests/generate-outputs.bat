csc *.cs
FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    WinterIsComing.exe < "%%f" > "!file:.in.txt=.out.txt!"
)
