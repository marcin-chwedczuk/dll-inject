#include <Windows.h>

static volatile int exitThreads = 0;
static HANDLE evilThread = NULL;

DWORD WINAPI EvilThread(LPVOID)
{
	HANDLE  hStdout = NULL;
	if ((hStdout = GetStdHandle(STD_OUTPUT_HANDLE)) == INVALID_HANDLE_VALUE)
		return 1;

	char message[] = "\r\nDLL_INJECTED\r\n";
	while (!exitThreads) {
		WriteConsoleA(hStdout, message, sizeof(message), NULL, NULL);
		Sleep(1500);
	}

	return 0;
}

BOOL WINAPI DllMain(
	HINSTANCE hinstDLL,  // handle to DLL module
	DWORD fdwReason,     // reason for calling function
	LPVOID lpReserved)   // reserved
{
	DWORD threadId;

	// Perform actions based on the reason for calling.
	switch (fdwReason)
	{
	case DLL_PROCESS_ATTACH:
		// Initialize once for each new process.
		// Return FALSE to fail DLL load.
		evilThread = CreateThread(NULL, 0, &EvilThread, NULL, 0, &threadId);
		if (!evilThread)
			return false;
		break;

	case DLL_THREAD_ATTACH:
		// Do thread-specific initialization.
		break;

	case DLL_THREAD_DETACH:
		// Do thread-specific cleanup.            
		break;

	case DLL_PROCESS_DETACH:
		// Perform any necessary cleanup.
		exitThreads = 1;
		if (evilThread) {
			WaitForSingleObject(evilThread, INFINITE);
			evilThread = NULL;
		}
		break;
	}

	return TRUE;
}