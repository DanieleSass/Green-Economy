# Green-Economy
Il nostro progetto consiste in un’applicazione C# WinForms progettata per l’analisi ambientale della temperatura e del livello dell' inquinamento di un comune italiano in relazione al giorno ed ora. Sfrutta l' API di Open-Meteo per prendere i valori in tempo reale, per dopo salvarli in un file json.

È possibile scegliere, direttamente dalle impostazioni accessibili in alto a destra, il comune, quali parametri analizzare (temperatura; inquinamento; entrambi) e a partire da che giorno fino ad oggi.
Con il tasto in alto a sinistra (di fianco a quello per la guida) è possibile inoltre aggiornare i dati, se ce ne sono di nuovi di disponibili.
Con il tasto in basso a sinistra è possibile uscire dal programma, decidendo se salvare gli ultimi dati analizzati in un file json oppure no.

Il programma dispone di una tabella (DataGridView) in cui è possibile visualizzare schematicamente i valori relazionati tra di loro; e un grafico che mostra in maniera visiva l'andamento nel tempo di inquinamento e temperatura. Nell' asse x c'è la data e ora, nell' asse y i valori di inquinamento e temperatura.
È presente inoltre un altra finestra (Form) per vedere uno schema grafico che relaziona solo la temperatura sull' asse x e l' inquinamento sull' asse y; insieme ad un' altra tabella che mostra dei riepiloghi statistici dei dati.
