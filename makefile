
ODIR=ship
SRCDIR=..

CS_FLAGS=/debug:full /incr+

!ifdef DEBUG
ODIR=debug
CS_FLAGS=$(CS_FLAGS) /define:DEBUG /debug:full /debug+
!endif

target: chdir Yasc.exe

clean: 
	-del /q $(ODIR)\*.*
	
chdir:
	@-mkdir $(ODIR) > NUL 2>&1
	@cd $(ODIR)  
	@echo Changed directory to $(ODIR)...

AssemblyInfo.netmodule: ..\AssemblyInfo.cs
	csc $(CS_FLAGS) /target:module /out:AssemblyInfo.netmodule ..\AssemblyInfo.cs

$(SRCDIR)\calendar.cs:
	wsdl http://www.thetasoft.com/calendar/cal.asmx /o:$(SRCDIR)\calendar.cs

Yasc.exe: AssemblyInfo.netmodule $(SRCDIR)\yasc.cs $(SRCDIR)\App.ico $(SRCDIR)\calendar.cs $(SRCDIR)\NewItem.cs $(SRCDIR)\CalItemInspector.cs $(SRCDIR)\hover.cs $(SRCDIR)\filter.cs
	csc $(CS_FLAGS) /target:winexe /out:Yasc.exe /addmodule:AssemblyInfo.netmodule $(SRCDIR)\yasc.cs $(SRCDIR)\calendar.cs $(SRCDIR)\NewItem.cs $(SRCDIR)\CalItemInspector.cs $(SRCDIR)\hover.cs $(SRCDIR)\filter.cs
	

        
