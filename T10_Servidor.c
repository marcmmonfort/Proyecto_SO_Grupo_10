// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

// SISTEMAS OPERATIVOS (SO).
// SERVIDOR del GRUPO 10, por:
// ---> Eloi Moncho Roig, eloi.moncho@estudiantat.upc.edu.
// ---> Alba Serra Muchart, alba.serra.muchart@estudiantat.upc.edu.
// ---> Marc Moran Monfort, marc.moran@estudiantat.upc.edu.

// - - - - - - - - - - - - - - - - - - - - - - LIBRERIAS - - - - - - - - - - - - - - - - - - - - - -

#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <ctype.h>
#include <mysql.h>
#include <pthread.h>
#define MAX_JUGADORES 4

// - - - - - - - - - - - - - - - - - - - - - - ESTRUCTURAS - - - - - - - - - - - - - - - - - - - - -

// [1]. Conectado.
typedef struct 
{
	char nombre[20];
	int socket;
	int partidaActual;
} Conectado;

// [2]. Lista de Conectados.
typedef struct 
{
	Conectado conectados[100];
	int num;
} ListaConectados;

// [3]. Jugador.
typedef struct 
{
	char nombre[20];
} Jugador;

// [4]. Partida.
typedef struct 
{
	char fecha[20]; // Fecha en la que se juega.
	Jugador jugador[MAX_JUGADORES]; // 
	int njugadores;
	char ganador[20]; // Nombre del ganador.
	char resultados[100]; // [Marc-127.5/Miguel-100/Alba-80/Eloi-20]
	int IDPartida;
} Partida;

// [5]. Lista de Partidas.
typedef struct 
{
	Partida partidas[100];
	int num;
} ListaPartidas;

// - - - - - - - - - - - - - - - - - - - - - VARIABLES GLOBALES - - - - - - - - - - - - - - - - - -

ListaConectados miLista;
ListaPartidas listaPartidas;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int sockets[100];
int NUM_CONECTADOS = 0;

// - - - - - - - - - - - - - - - - - - - - - FUNCIONES DEL SERVIDOR - - - - - - - - - - - - - - - - -

// [1]. FUNCION PARA AÑADIR UN USUARIO A LA LISTA DE CONECTADOS.
// ---> Ejemplos INPUT: (miLista, "Marc", 4).
// ---> Ejemplos OUTPUT: (-1: lista llena), (-2: otro problema), (0: aï¿±adido OK).
int Pon (ListaConectados *lista,char nombre[20],int socket)
{
	int encontrado=0;
	int i=0;
	if (lista->num==100)
		return -1;
	else
	{
		while (i<lista->num && encontrado==0 )
		{
			if (strcmp(lista->conectados[i].nombre,nombre)==0)
			{
				encontrado=1;
				break;
			}
			i=i+1;
		}
		
		if (encontrado==0) {
			strcpy(lista->conectados[lista->num].nombre,nombre);
			lista->conectados[lista->num].socket=socket;
			lista->num++;
			return 0;
		}
		else
			return -2;
	}
}

// [2]. FUNCION QUE TE DA LA POSICION DE UN USUARIO DENTRO DE LA LISTA DE CONECTADOS.
// ---> Ejemplos INPUT: (miLista, "Marc").
// ---> Ejemplos OUTPUT: (-1: Marc no estï¿¡ conectado), (X: posiciï¿³n).
int DamePosicion (ListaConectados *lista,char nombre[20])
{
	int i=0;
	int encontrado=0;
	while ((i<lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre,nombre)==0)
			encontrado=1;
		if(!encontrado)
			i=i+1;
	}
	if (encontrado)
		return i;
	else
		return -1;
}

// [3]. FUNCION PARA AÑADIR UN USUARIO A LA LISTA DE CONECTADOS.
// ---> Ejemplos INPUT: (miLista, "Marc").
// ---> Ejemplos OUTPUT: (-1: Marc no estï¿¡ conectado), (X: socket).
int DameSocket (ListaConectados *lista, char nombre[20])
{
	int i=0;
	int encontrado=0;
	while ((i< lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre,nombre)==0)
			encontrado =1;
		if(!encontrado)
			i=i+1;
	}
	if (encontrado)
		return lista->conectados [i].socket;
	else
		return -1;
}

// [4]. FUNCION PARA ELIMINAR UN JUGADOR DE LA LISTA DE CONECTADOS CUANDO DEJE DE JUGAR.
// ---> Ejemplos INPUT: (miLista, "Marc").
// ---> Ejemplos OUTPUT: (-1: Marc ya no estaba en la lista), (0: eliminado correctamente).
int Eliminar (ListaConectados *lista,char nombre[20])
{
	int pos = DamePosicion (lista,nombre);
	if (pos==-1)
		return -1;
	else{
		int i;
		for (i=pos;i<lista->num;i++)
		{
			sockets[i] = sockets[i+1];
			lista->conectados[i]=lista->conectados[i+1];
		}
		lista->num--;
		NUM_CONECTADOS--;
		return 0;
	}
}

// [5]. FUNCION PARA RELLENAR UN VECTOR DE CARACTERES CON LOS NOMBRES DE LOS CONECTADOS.
// ---> Ejemplos INPUT: (miLista, []).
// ---> Como queda el vector de conectados: ([Marc|5-Eloi|6-Alba|7]).
void DameConectados (ListaConectados *lista,char conectados[300])
{
	sprintf(conectados,"%d",lista->num);
	int i;
	for (i=0;i<lista->num;i++)
	{
		sprintf(conectados,"%s-%s|%d",conectados,lista->conectados[i].nombre, DameSocket(&miLista,lista->conectados[i].nombre));
	}
}

// [6]. FUNCION PARA AÑADIR UNA PARTIDA A LA LISTA DE PARTIDAS.
// ---> Ejemplos INPUT: (listaPartidas, "Eloi").
// ---> Ejemplos OUTPUT: (-1: lista llena),(num: aï¿±adido OK).
int NuevaPartida (ListaPartidas *lista,char nombre[20])
{
	int posicion = DamePosicion(&miLista,nombre);
	if (lista->num==100)
		return -1;
	else
	{
		int number = lista->num;
		strcpy(lista->partidas[number].jugador[0].nombre,nombre);
		lista->partidas[number].njugadores=1;
		lista->partidas[number].IDPartida=number + 1;//la primera partida serï¿¡ la partida 1
		lista->num++;
		miLista.conectados[posicion].partidaActual=lista->partidas[number].IDPartida;
		return lista->partidas[number].IDPartida;
		
	}
}

// [7]. FUNCION PARA AÑADIR UN JUGADOR A UNA PARTIDA.
// ---> Ejemplos INPUT: (listaPartidas, "Marc",1).
// ---> Ejemplos OUTPUT: (-1: lista llena), (-2: otro problema), (0: anadido OK).
int  AnadirJugadoraPartida(ListaPartidas *lista,char nombre[20], int IDP)
{
	
	int i=0;
	int encontrado =0;
	printf("Anadir Jugador: %s a la partida #%d\n",nombre,IDP);
	int posicion = DamePosicion(&miLista,nombre);
	while (i<lista->num)
	{
		if (lista->partidas[i].IDPartida==IDP)
		{
			encontrado=1;
			break;
		}
		i++;
	}
	if(encontrado==1)
	{
		if (lista->partidas[i].njugadores<MAX_JUGADORES)
		{			
			if (lista->partidas[i].njugadores < MAX_JUGADORES)
			{
				int j = lista->partidas[i].njugadores;
				strcpy(lista->partidas[i].jugador[j].nombre,nombre);
				lista->partidas[i].njugadores++;
				printf("Jug. de la Partida %d: %d.\n", IDP, lista->partidas[i].njugadores);
				miLista.conectados[posicion].partidaActual=IDP;
				return 0;
			}
		}
		else 
			return -2; // Ya hay los 4 jugadores en la partida
	}
	else
	   return -1;// No existe ese ID de partida
	
}

// [8]. FUNCION QUE RETORNA LA LISTA DE PARTIDAS.
// ---> Ejemplos INPUT: (miLista, []).
// ---> Como queda el vector de partidas: (#-Marc|1-Eloi|1-Alba|1-Miguel|1...Antonia|4-Pau|4]).
void DamePartidas (ListaPartidas *lista,char partidas[1000])
{
	sprintf(partidas,"%d",lista->num); // Primero se pone el número de partidas que hay.
	int i;
	for (i=0;i<lista->num;i++)
	{
		for (int j=0;j<lista->partidas[i].njugadores;j++)
			sprintf(partidas,"%s-%s|%d",partidas,lista->partidas[i].jugador[j].nombre, lista->partidas[i].IDPartida);
	}
}

// [9]. FUNCION QUE TE DA LA POSICION DE UNA PARTIDA DENTRO DE LA LISTA DE PARTIDAS.
// ---> Ejemplos INPUT: (miLista, Partida).
// ---> Ejemplos OUTPUT: (-1: Marc no estï¿¡ conectado), (X: posiciï¿³n).
int DamePosicionPartida(ListaPartidas *lista, int id)
{
	int i=0;
	int encontrado;
	while (i<100)
	{
		if (lista->partidas[i].IDPartida==id)
		{
			encontrado=1;
			break;
		}
		i=i+1;
	}
	if (encontrado)
	{
		return i;
	}
	else
		return -1;
}
	
// [10]. FUNCION PARA ELIMINAR UNA PARTIDA DE LA LISTA DE PARTIDAS CUANDO SE ACABE UNA PARTIDA.
// ---> Ejemplos INPUT: (miLista, Partida).
// ---> Ejemplos OUTPUT: (-1: Marc ya no estaba en la lista), (0: eliminado correctamente)
int EliminarPartida (ListaPartidas *lista, int id)
{
	int pos = DamePosicionPartida (lista, id);
	if (pos==-1)
		return -1;
	else
	{
		int posicion;
		for(int j=0;j<MAX_JUGADORES;j++)
		{
			int posicion = DamePosicion(&miLista,lista->partidas[pos].jugador[j].nombre);
			miLista.conectados[posicion].partidaActual=0;
		}
		int i;
		for (i=pos;i<lista->num -1;i++)
		{
			lista->partidas[i]=lista->partidas[i+1];
		}
		lista->num--;
		
		return 0;
	}
}

// [11]. FUNCION QUE, CON EL NOMBRE DE UN USER, TE DEVUELVE LOS NOMBRES DE LOS DEMAS USUARIOS DE LA MISMA PARTIDA.
// ---> Ejemplos INPUT: (&listaPartidas, Marc).
// ---> Ejemplos OUTPUT: (-1: No está en ninguna partida. | 0: Se ha encontrado. | [Marc,Eloi,Alba]). ---> Devuelve los demás jugadores (sockets) de la partida.
int DameIndicePartida (ListaPartidas *lista, char nom[20], char NombresMismaPartida[1000])
{	
	int m=0;
	int encontrado = -1;
	
	// Encontramos los nombres de los otros jugadores de la partida.
	while ((m<lista->num) && (encontrado==-1))
	{
		printf(">>> INDICE PARTIDA: %d\n", m); // #AQUI
		int jugadors = lista->partidas[m].njugadores;
		printf(">>> NUM JUG PARTIDA: %d\n", jugadors); // #AQUI
		
		// Llegim tots els noms de la partida.
		int n;
		for (n=0; n<jugadors; n++);
		{
			printf(">>> JUGADOR D'UNA PARTIDA: %s\n", lista->partidas[m].jugador[n].nombre); // #AQUI
			if (strcmp(lista->partidas[m].jugador[n].nombre, nom) == 0) // Si encontramos nuestro nombre:
			{
				// El jugador està a aquesta partida i té numero n.
				printf(">>> INDICE NUESTRA PARTIDA: %d\n", m); // #AQUI
				for (int s=0; s<jugadors; s++)
				{
					if (strcmp(nom,lista->partidas[m].jugador[s].nombre)!=0) // Si no es el nombre del que está pidiendo a sus compañeros...
					{
						sprintf(NombresMismaPartida, "%s%s,", NombresMismaPartida, lista->partidas[m].jugador[s].nombre);
						printf(">>> NOMS RIVALS: %s\n", lista->partidas[m].jugador[s].nombre); // #AQUI1
					}
				}
				encontrado = 0;
			}
		}
		m=m+1;
	}
	
	// Limpiamos la última coma de los nombres:
	// int PosComa = strlen(NombresMismaPartida)-1;
	// NombresMismaPartida[PosComa]="\0";
	// Queda: [Juan,Jose,Pedro]
	
	return encontrado;
}

// - - - - - - - - - - - - - - - - - - - - - CONSULTAS - - - - - - - - - - - - - - - - - - - - - - -

// [1]. CONSULTA PARA OBTENER EL NÚMERO DE PARTIDAS QUE HA JUGADO UN JUGADOR.
// ---> Ejemplos INPUT: ("Marc").
// ---> Ejemplos OUTPUT: (X: numero de partidas).
int NumPartidas(char nombre[50]) 
{
	int partidas;
	
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	conn = mysql_init(NULL);
	
	if (conn==NULL) {
		partidas = -1;
		exit (1);
	}
	// conn = mysql_real_connect (conn, "localhost","root", "mysql", "Diez",0, NULL, 0);
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T10_BBDD",0, NULL, 0);
	if (conn==NULL) {
		partidas = -1;
		exit (1);
	}
	
	char mensaje[1000];
	strcpy(mensaje, "SELECT count(*) FROM (Jugador, Participacion) WHERE (Jugador.usuario = '");
	strcat(mensaje, nombre);
	strcat(mensaje, "') AND (Participacion.IDJ = Jugador.IDJugador);");
	
	err = mysql_query (conn, mensaje);
	if (err!=0) {
		partidas = -1;
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
		partidas = -1;
	else {
		partidas = atoi(row[0]);
	}
	
	mysql_close(conn);
	
	return partidas;
}

// [2]. CONSULTA PARA OBTENER EL NUMERO DE CREDITOS QUE HA CONSEGUIDO UN JUGADOR EN UNA FECHA DETERMINADA.
// ---> Ejemplos INPUT: ("Marc", "10/10/2021").
// ---> Ejemplos OUTPUT: (X: numero de creditos).
int SumaCreditos(char ganador[50], char fecha[50]) 
{
	
	int sumCreditos;
	
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	conn = mysql_init(NULL);
	
	if (conn==NULL) {
		sumCreditos = -1;
		exit (1);
	}
	// conn = mysql_real_connect (conn, "localhost","root", "mysql", "Diez",0, NULL, 0);
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T10_BBDD",0, NULL, 0);
	if (conn==NULL) {
		sumCreditos = -1;
		exit (1);
	}
	
	
	char mensaje[1000];
	strcpy(mensaje, "SELECT Participacion.sumaCreditos FROM (Partida, Participacion, Jugador) WHERE Partida.ganador = '");
	strcat(mensaje, ganador);
	strcat(mensaje, "' AND Jugador.usuario = '");
	strcat(mensaje, ganador);
	strcat(mensaje, "' AND Partida.fecha = '");
	strcat(mensaje, fecha);
	strcat(mensaje, "' AND (Partida.IDPartida = Participacion.IDP) AND (Jugador.IDJugador = Participacion.IDJ);");
	err = mysql_query (conn, mensaje);
	if (err!=0) {
		sumCreditos = -1;
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
		sumCreditos = -1;
	else {
		sumCreditos = atoi(row[0]);
	}
	
	mysql_close(conn);
	// exit(0);
	
	return sumCreditos;
}

// [3]. CONSULTA PARA OBTENER LOS JUGADORES A LOS QUE HA GANADO EL JUGADOR INTRODUCIDO COMO PARAMETRO.
// ---> Ejemplos INPUT: ("Marc", []).
// ---> Ejemplos OUTPUT: (0: todo bien).
// ---> Como queda el vector de perdedores: ([Eloi/Alba]).
int GanadorContra(char nombre[50], char * perdedores)
{
	
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	conn = mysql_init(NULL);
	
	if (conn==NULL) {
		exit (1);
	}
	// conn = mysql_real_connect (conn, "localhost","root", "mysql", "Diez",0, NULL, 0);
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T10_BBDD",0, NULL, 0);
	if (conn==NULL) {
		exit (1);
	}
	
	char mensaje[1000];
		
	strcpy(mensaje, "SELECT IDJugador FROM Jugador WHERE usuario = '");
	strcat(mensaje, nombre);
	strcat(mensaje, "';");
	
	err = mysql_query (conn, mensaje);
	if (err!=0) {
		exit(1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	strcpy(mensaje, "SELECT distinct(usuario) from (Jugador,Participacion,Partida) where Jugador.IDJugador = Participacion.IDJ and Partida.IDPartida = Participacion.IDP and Partida.ganador='");
	strcat(mensaje, nombre);
	strcat(mensaje, "'and Participacion.IDJ<>");
	strcat(mensaje, row[0]);
	strcat(mensaje, ";");
	
	err = mysql_query (conn, mensaje);
	if (!err) {
		
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
	
		while (row != NULL){
			strcat (perdedores, row[0]);
			strcat (perdedores, "/");
			row = mysql_fetch_row(resultado);
		}
		
		if ((strlen(perdedores))!=0)
		{
			perdedores[strlen(perdedores)-1]='\0';
		}
	}		
	
	mysql_close(conn);
	return 0;
}

// [4]. CONSULTA PARA COMPROBAR SI UN USUARIO ESTA EN LA BBDD.
// ---> Ejemplos INPUT: ("Marc").
// ---> Ejemplos OUTPUT: (1: existe el usuario y la contraseña es la correcta), (0: no existe).
int CheckNombre(char nombre[50])
{
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	// conn = mysql_real_connect (conn, "localhost","root", "mysql", "Diez",0, NULL, 0);
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T10_BBDD",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	char mensaje[1000];
	strcpy(mensaje, "SELECT (Jugador.contra) FROM (Jugador) WHERE (Jugador.usuario = '");
	strcat(mensaje, nombre);
	strcat(mensaje, "');");
	
	err = mysql_query (conn, mensaje);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row != NULL)
	{
		printf("¡Nombre YA existe!\n");
		return 1;
	}
	else
	{
		printf("¡Nombre NO existe!\n");
		return 0;
	}
	mysql_close(conn);
}

// [5]. CONSULTA PARA COMPROBAR LA CONTRASEÑA DE UN USUARIO EN LA BASE DE DATOS.
// ---> Ejemplos INPUT: ("Marc", "pingpong").
// ---> Ejemplos OUTPUT: (0: contraseña correcta), (-1: contraseña incorrecta).
int CheckPassword(char nombre[50], char contra[50]) 
{
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	// conn = mysql_real_connect (conn, "localhost","root", "mysql", "Diez",0, NULL, 0);
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T10_BBDD",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	char mensaje[1000];
	strcpy(mensaje, "SELECT (Jugador.contra) FROM (Jugador) WHERE (Jugador.usuario = '");
	strcat(mensaje, nombre);
	strcat(mensaje, "');");
	
	err = mysql_query (conn, mensaje);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	char contraVerdadera[50];
	
	if (row == NULL)
		printf ("¡No se han obtenido datos en la consulta!\n");
	else {
		strcpy(contraVerdadera,row[0]);
	}
	
	mysql_close(conn);
		
	if (strcmp(contraVerdadera, contra) == 0)
	{
		return 0;
	}
	else
	{
		return -1;
	}
}

// [6]. CONSULTA PARA REGISTRAR A UN NUEVO USUARIO.
// ---> Ejemplos INPUT: ("Marc", "pingpong").
// ---> Ejemplos OUTPUT: (-1: ya existia, por eso no se ha hecho el register), (0: registro correcto).
int Register(char nombre[50], char contra[50]) 
{
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	conn = mysql_init(NULL);
	
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	// conn = mysql_real_connect (conn, "localhost","root", "mysql", "Diez",0, NULL, 0);
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T10_BBDD",0, NULL, 0);
	
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	int existe = CheckNombre(nombre);
	if (existe == 0) //Si no existe el nombre de usuario introducido
	{ 
		char mensaje[1000];
		strcpy(mensaje, "INSERT INTO Jugador(usuario,contra) VALUES ('");
		strcat(mensaje, nombre);
		strcat(mensaje, "','");
		strcat(mensaje, contra);
		strcat(mensaje, "');");
		
		err = mysql_query (conn, mensaje);
		if (err!=0)
		{
			printf ("Error al consultar datos de la base %u %s\n",
					mysql_errno(conn), mysql_error(conn));
			return -1;
			exit (1);
		}
		else
			printf("¡Valores Introducidos!\n");
			return 0;
	}
	else if (existe==1)
		return 1;
	else 
		return -1;
	
	mysql_close(conn);
}

// - - - - - - - - - - - - - - FUNCIÓN PARA ATENDER A UN CLIENTE - - - - - - - - - - - - - - - - - -

void *AtenderCliente(void *socket)
{
	int sock_conn;
	int*s;
	s=(int*)socket;
	sock_conn=*s;
	char peticion[1000];
	char respuesta[1000];
	int ret;

	int terminar = 0;
	
	// BUCLE INFINITO PARA ESCUCHAR TODAS LAS PETICIONES HASTA QUE UN CLIENTE SE DESCONECTE:
	while (terminar == 0)
	{
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("¡Recibido!\n");
		peticion[ret]='\0';	
		printf ("---> Peticion: %s\n",peticion);
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p); // ID de la peticion.
	
		// [0]. DESCONECTAMOS UN CLIENTE.
		if (codigo == 0)
		{
			terminar = 1;				
			char nombre[50];
			p = strtok(NULL, "/");
			strcpy (nombre, p);	
			Eliminar (&miLista, nombre);
			int i=0;
			while (i<miLista.num)
			{
				printf("%s\n",miLista.conectados[i].nombre);
				i++;
			}
		}
			
		// [1]. PETICION DEL NUMERO DE CREDITOS GANADOS POR UN JUGADOR UN CIERTO DIA.
		else if (codigo ==1)
		{
			pthread_mutex_lock( &mutex);
			
			char ganador[50]; // Nombre del usuario que pregunta.
			p = strtok( NULL, "/");
			strcpy (ganador, p);				
			char fecha[50]; // Fecha de la partida.
			p = strtok(NULL, ".");
			strcpy (fecha, p);
			int sumCreditos = SumaCreditos(ganador, fecha);
			char answer[20];
			sprintf(answer, "1/%d\n", sumCreditos);
			strcpy (respuesta,answer); // Devuelve, en respuesta, el número de créditos.
			printf ("<--- Respuesta: %s \n",respuesta);
			
			write (sock_conn,respuesta,strlen(respuesta)); // SE RESPONDE AL QUE HACE LA PETICION.
			
			pthread_mutex_unlock( &mutex);
		}
		
		// [2]. PETICION DEL NUMERO DE PARTIDAS JUGADAS POR UN CIERTO JUGADOR.
		else if (codigo ==2)
		{
			pthread_mutex_lock( &mutex);
			
			char nombre[50]; // Ponemos en 'nombre' el nombre del usuario que pregunta.
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			int partidas = NumPartidas(nombre);
			char answer[20];
			sprintf(answer, "2/%d\n", partidas);
			strcpy (respuesta,answer); // Devuelve el numero de partidas como respuesta.
			printf ("<--- Respuesta: %s \n",respuesta);
			
			write (sock_conn,respuesta,strlen(respuesta)); // SE RESPONDE AL QUE HACE LA PETICION.
			
			pthread_mutex_unlock( &mutex);
		}
			
		// [3]. PETICION DE LOS NOMBRES DE LOS RIVALES A LOS QUE UN CIERTO JUGADOR HA GANADO.
		else if (codigo ==3)
		{
			pthread_mutex_lock( &mutex);
			
			char nombre[50];
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			char perdedores [512];
			strcpy (perdedores, "\0");
			int ret = GanadorContra(nombre, perdedores);
			sprintf (respuesta,"3/%s\n",perdedores); // Devuelve la lista de jugadores que han perdido contra el usuario seleccionado.
			printf ("<--- Respuesta: %s \n",respuesta);
			
			write (sock_conn,respuesta,strlen(respuesta)); // SE RESPONDE AL QUE HACE LA PETICION.
			
			pthread_mutex_unlock( &mutex);
		}
			
		// [4]. PETICION DE LOGIN.
		else if (codigo ==4)
		{
			pthread_mutex_lock( &mutex);			
			
			char nombre[50];
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			char contrasena[50];
			p = strtok( NULL, "/");
			strcpy (contrasena, p);
			int verificar = CheckPassword(nombre,contrasena);
			char answer[20];
			sprintf(answer, "4/%d\n", verificar);
			strcpy (respuesta,answer);
			printf ("<--- Respuesta: %s \n",respuesta);
			
			write (sock_conn,respuesta,strlen(respuesta)); // SE RESPONDE AL QUE HACE LA PETICION.
			if (verificar==0)
			{
				if (miLista.num <=100) 
				{
					Pon (&miLista, nombre, sock_conn);
				}
				
			}
			
			pthread_mutex_unlock( &mutex);
		}
			
		// [5]. PETICION DE REGISTRO.
		else if (codigo ==5)
		{
			pthread_mutex_lock( &mutex);
			
			char nombre[50];
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			char contrasena[50];
			p = strtok( NULL, "/");
			strcpy (contrasena, p);
			int registrar = Register(nombre,contrasena);
			sprintf(respuesta,"5/%d\n", registrar);
			printf ("<--- Respuesta: %s \n",respuesta);
			
			write (sock_conn,respuesta,strlen(respuesta)); // SE RESPONDE AL QUE HACE LA PETICION.
			
			pthread_mutex_unlock( &mutex);
		}	
		
		// [10]. REENVIO DE LA INVITACIÓN DE UNA PARTIDA A LOS JUGADORES QUE HAN SIDO INVITADOS.
		else if (codigo == 10) // SI SE RECIBE UNA PETICIÓN. Fer que la peticion 10 sigui "10/creador"
		{
			pthread_mutex_lock( &mutex);
			
			char creador[50];
			p = strtok( NULL, "/");
			strcpy (creador, p);
			
			int posicion=(DamePosicion(&miLista,creador));
			if(miLista.conectados[posicion].partidaActual!=0)
			{
				strcpy(respuesta, "10/-1"); //Poso coma per distingir del guió si retornés -1
				write (sock_conn,respuesta,strlen(respuesta)); // SE RESPONDE AL QUE HACE LA PETICION.
			}
			else
			{
				
				char conectados[512];
				int IdPartida = NuevaPartida(&listaPartidas,creador);
				sprintf(respuesta, "10/%s,%d\n",creador,IdPartida); //Poso coma per distingir del guió si retornés -1
				//int socketCreador =DameSocket(&miLista,creador);
				int j; 
				printf("<--- Respuesta: %s \n",respuesta);
				
				for (j=0; j<miLista.num; j++) 
				{			
					if (miLista.conectados[j].partidaActual==0) // SE RESPONDE A TODOS USUARIOS EXCEPTO AL CREADOR.
						write (sockets[j], respuesta, strlen(respuesta));
				}
				
			}
			
			pthread_mutex_unlock( &mutex);
		}
		
		// [11]. RESPUESTA A UNA INVITACIÓN.
		else if (codigo == 11) // Recibimos: ("11/YES/Marc/#IDP"), y lo interpretamos:
		{
			pthread_mutex_lock(&mutex);
			
			char respuesta[500];
			char nombre[100];
			char YESorNO[100];
			p = strtok (NULL, "/");
			strcpy (YESorNO, p);
			p = strtok (NULL, "/");
			strcpy (nombre, p);
			
			p = strtok (NULL, "/");
			int idPartida = atoi(p);
			int PosMiPartida = DamePosicionPartida(&listaPartidas, idPartida);
			printf(">>> POSICION MI PARTIDA: %d\n", PosMiPartida);
			
			if (strcmp(YESorNO,"YES")==0)
			{
				char partidas[1000];
				DamePartidas(&listaPartidas,partidas);
				int anadir = AnadirJugadoraPartida(&listaPartidas, nombre, idPartida);
				
				if (anadir ==0)
				{
					printf("¡Añadido correctamente!\n");
					char partidas[1000];
					DamePartidas(&listaPartidas,partidas);
					char respuesta[1000];
					sprintf(respuesta,"12/%s",partidas); // #ERRORES
					printf ("<--- Respuesta: %s \n",respuesta);
					int j;
					
					for (j=0; j<miLista.num; j++) 
					{	// SE RESPONDE A LOS USUARIOS QUE CONVIENE.
						write (sockets[j], respuesta, strlen(respuesta)); // Escribimos a todos el mensaje de YES or NO.
					}
					if (listaPartidas.partidas[idPartida-1].njugadores==MAX_JUGADORES)
					{
						usleep(500000); // 0,5 Segundos de Delay (microsegundos) para que vayan coordinados.
						int vec_sockets[MAX_JUGADORES];
						for (int i=0;i<MAX_JUGADORES;i++)
						{
							char nombreJugador[20];
							strcpy(nombreJugador, listaPartidas.partidas[PosMiPartida].jugador[i].nombre);
							vec_sockets[i]=DameSocket(&miLista,nombreJugador);
						}
						
						char answer[1000];
						sprintf(answer,"14/");
						
						// Cuando indicamos a los formularios que abran el tablero, antes asociamos un numero de ficha a cada usuario.
						// Preparará: "14/Marc|Eloi|Alba|Miguel"
						for (int l=0;l<MAX_JUGADORES-1;l++)
						{
							char nombre[20];
							strcpy(nombre, listaPartidas.partidas[PosMiPartida].jugador[l].nombre);
							sprintf(answer, "%s%s|", answer, nombre);
						}
						// El ultimo lo ponemos sin barra:
						char nombre[20];
						strcpy(nombre, listaPartidas.partidas[PosMiPartida].jugador[3].nombre);
						sprintf(answer, "%s%s", answer, nombre);
						
						// Se reenvía a los de la partida el mensaje del tipo "14/Marc|Eloi|Alba|Miguel".
						for (int k=0; k<MAX_JUGADORES; k++) 
						{	// SE RESPONDE A LOS USUARIOS QUE CONVIENE.
							write (vec_sockets[k], answer, strlen(answer)); // Escribimos a todos el mensaje de YES or NO.
							printf ("ABRIR FORM '%s' al socket '%d'.\n",answer, vec_sockets[k]);
						}
					}
				}
				else if (anadir == -1) // El id de Partida no existe
				{
					sprintf(respuesta, "12/%d\n", anadir);
					printf ("<--- Respuesta: %s \n",respuesta);
					write (sock_conn,respuesta,strlen(respuesta)); // SE RESPONDE AL QUE HACE LA PETICION.
				}
				else //anadir = -2 La partida ya está completa
				{
					sprintf(respuesta, "12/%d\n", anadir);
					printf ("<--- Respuesta: %s \n",respuesta);
					write (sock_conn,respuesta,strlen(respuesta)); // SE RESPONDE AL QUE HACE LA PETICION.
				}
			}
			pthread_mutex_unlock( &mutex);
		}
		
		// [13]. AVISO DE QUE ALGUIEN HA RECHAZADO LA PARTIDA Y, POR LO TANTO, NO SE VA A JUGAR.
		else if (codigo == 13)
		{
			pthread_mutex_lock( &mutex);
			
			char total[10];
			sprintf(total, "13/\n");
			printf ("<--- Respuesta: %s \n",total);
			
			int j;
			for (j=0; j<miLista.num; j++) {	// SE RESPONDE A LOS USUARIOS QUE CONVIENE.		
				write (sockets[j], total, strlen(total));
			}
			
			pthread_mutex_unlock( &mutex);
		}
		
		// [55]. AVISO DE QUE TODOS HAN ACEPTADO Y, POR LO TANTO, SE VA A JUGAR LA PARTIDA.
		else if (codigo == 55)
		{
			pthread_mutex_lock( &mutex);
			
			char total[10];
			sprintf(total, "55/\n");
			printf ("<--- Respuesta: %s \n",total);
			
			write (sock_conn,total,strlen(total)); // SE RESPONDE AL QUE HACE LA PETICION.
			
			pthread_mutex_unlock( &mutex);
		}

		// [15].INVITACION A JUGADORES AMIGOS.
		else if (codigo == 15)
		{
			pthread_mutex_lock( &mutex);
			char creador[50];
			p = strtok( NULL, "/");
			strcpy (creador, p);
			int IDPartida = NuevaPartida(&listaPartidas, creador);
			sprintf (respuesta,"10/%s,%d\n",creador,IDPartida);
			printf("<--- Respuesta: %s \n",respuesta);
			
			int i = 0;
			while (p!= NULL)
			{
				char invitado[20];
				p = strtok( NULL, "/");
				strcpy (invitado, p);
				int s = DameSocket(&miLista, invitado);
				write (s, respuesta, strlen(respuesta));
				p = strtok(NULL, "/");
			}
			pthread_mutex_unlock( &mutex);
		}
		
		// [28]. SE RECIBE LA NOTIFICACION DE UN MENSAJE NUEVO EN EL CHAT.
		// Se recibe con el formato: "28/user-IDP/(13:36) Marc: Hola!"
		else if (codigo == 28)
		{
			pthread_mutex_lock( &mutex);
			
			char userIDP[100];// "user-IDP"
			p = strtok(NULL, "/");
			strcpy(userIDP, p);
			
			char missatge[500];
			p = strtok(NULL, "/"); // "(13:36) Marc: Hola!"
			sprintf(missatge, "28/%s", p); // Enviará a los clientes el mensaje: "28/(13:36) Marc: Hola!" ||| #AQUI he quitado un \n.
			printf ("<--- Respuesta: %s\n",missatge); 
			
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * MECANISMO DE REENVIO A LOS JUGADORES DE LA MISMA PARTIDA * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			char quienEnvia[20];
			char *q = strtok(userIDP, "-");
			strcpy(quienEnvia,q);
			printf(">>> QUIEN ENVIA: %s\n", quienEnvia);
			q = strtok(NULL, "-");
			int idMiPartida = atoi(q);
			printf(">>> PARTIDA DEL QUE ENVIA: %d\n", idMiPartida);
			int PosMiPartida = DamePosicionPartida(&listaPartidas, idMiPartida);
			printf(">>> POSICION DE LA PARTIDA DEL QUE ENVIA: %d\n", PosMiPartida);
			int otrosSockets[MAX_JUGADORES];
			for (int i=0;i<MAX_JUGADORES;i++)
			{
				char nombreJugador[20];
				strcpy(nombreJugador, listaPartidas.partidas[PosMiPartida].jugador[i].nombre);
				if (strcmp(nombreJugador,quienEnvia)==0) {
					otrosSockets[i]=-1;
				}
				else {
					otrosSockets[i]=DameSocket(&miLista,nombreJugador);
				}
				printf(">>> SE AÑADE EL SOCKET A REENVIAR %d\n", otrosSockets[i]);
			}
			for (int j=0; j<4; j++) { // SE RESPONDE A LOS OTROS DE LA PARTIDA	
				if (otrosSockets[j]!=-1) // Si no es el socket del que ha hecho la petición ...
				{
					write (otrosSockets[j], missatge, strlen(missatge));
					printf ("ENVIA '%s' al socket '%d'.\n",missatge, otrosSockets[j]);
				}
			}
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			
			pthread_mutex_unlock( &mutex);
		}
		
		// [52]. SE PIDE QUE SE ENVIE UNA NOTIFICACION A TODOS LOS DEMAS JUGADORES DE LA PARTIDA.
		// Se recibe con el formato: '52/Marc-1/[JUGADOR 1: Marc] -> Ha pasado por meta. Gana 500 Euros.'
		// Se envia con el formato: '52/[JUGADOR 1: Marc] -> Ha pasado por meta. Gana 500 Euros.'
		else if (codigo == 52)
		{
			pthread_mutex_lock( &mutex);
			
			char userIDP[100];// "user-IDP"
			p = strtok(NULL, "/");
			strcpy(userIDP, p);
			char missatge[500];
			p = strtok(NULL, "/"); // "[JUGADOR 1: Marc] -> Ha pasado por meta. Gana 500 Euros."
			sprintf(missatge, "52/%s", p); // Enviará a los clientes el mensaje: "52/[JUGADOR 1: Marc] -> Ha pasado por meta. Gana 500 Euros.
			printf ("<--- Respuesta: %s\n",missatge); 
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * MECANISMO DE REENVIO A LOS JUGADORES DE LA MISMA PARTIDA * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			char quienEnvia[20];
			char *q = strtok(userIDP, "-");
			strcpy(quienEnvia,q);
			printf(">>> QUIEN ENVIA: %s\n", quienEnvia);
			q = strtok(NULL, "-");
			int idMiPartida = atoi(q);
			printf(">>> PARTIDA DEL QUE ENVIA: %d\n", idMiPartida);
			int PosMiPartida = DamePosicionPartida(&listaPartidas, idMiPartida);
			printf(">>> POSICION DE LA PARTIDA DEL QUE ENVIA: %d\n", PosMiPartida);
			int otrosSockets[MAX_JUGADORES];
			for (int i=0;i<MAX_JUGADORES;i++)
			{
				char nombreJugador[20];
				strcpy(nombreJugador, listaPartidas.partidas[PosMiPartida].jugador[i].nombre);
				if (strcmp(nombreJugador,quienEnvia)==0) {
					otrosSockets[i]=-1;
				}
				else {
					otrosSockets[i]=DameSocket(&miLista,nombreJugador);
				}
				printf(">>> SE AÑADE EL SOCKET A REENVIAR %d\n", otrosSockets[i]);
			}
			for (int j=0; j<4; j++) { // SE RESPONDE A LOS OTROS DE LA PARTIDA	
				if (otrosSockets[j]!=-1) // Si no es el socket del que ha hecho la petición ...
				{
					write (otrosSockets[j], missatge, strlen(missatge));
					printf ("ENVIA '%s' al socket '%d'.\n",missatge, otrosSockets[j]);
				}
			}
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			
			pthread_mutex_unlock( &mutex);
		}
		
		// [53]. SE AVISA DEL CAMBIO DE TURNO A TODOS LOS JUGADORES DE LA PARTIDA:
		// Se recibe con el formato: '53/Marc-1/turno'
		// Se envia con el formato: '53/turno'
		else if (codigo == 53)
		{
			pthread_mutex_lock( &mutex);
			
			char userIDP[100];// "user-IDP"
			p = strtok(NULL, "/");
			strcpy(userIDP, p);
			
			char missatge[500];
			p = strtok(NULL, "/"); // "turno"
			sprintf(missatge, "53/%s", p); // Enviará a los clientes el mensaje: "53/turno"
			printf ("<--- Respuesta: %s\n",missatge); 
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * MECANISMO DE REENVIO A TODOS LOS JUGADORES DE LA MISMA PARTIDA * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			char quienEnvia[20];
			char *q = strtok(userIDP, "-");
			strcpy(quienEnvia,q);
			printf(">>> QUIEN ENVIA: %s\n", quienEnvia);
			q = strtok(NULL, "-");
			int idMiPartida = atoi(q);
			printf(">>> PARTIDA DEL QUE ENVIA: %d\n", idMiPartida);
			int PosMiPartida = DamePosicionPartida(&listaPartidas, idMiPartida);
			printf(">>> POSICION DE LA PARTIDA DEL QUE ENVIA: %d\n", PosMiPartida);
			int otrosSockets[MAX_JUGADORES];
			for (int i=0;i<MAX_JUGADORES;i++)
			{
				// EN ESTE CASO, QUEREMOS QUE LO REENVIE A TODOS LOS DE LA PARTIDA, INCLUIDO EL QUE LO PIDE:
				char nombreJugador[20];
				strcpy(nombreJugador, listaPartidas.partidas[PosMiPartida].jugador[i].nombre);
				otrosSockets[i]=DameSocket(&miLista,nombreJugador);
				printf(">>> SE AÑADE EL SOCKET A REENVIAR %d\n", otrosSockets[i]);
			}
			for (int j=0; j<4; j++) { // SE RESPONDE A LOS OTROS DE LA PARTIDA	
				write (otrosSockets[j], missatge, strlen(missatge));
				printf ("ENVIA '%s' al socket '%d'.\n",missatge, otrosSockets[j]);
			}
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			
			pthread_mutex_unlock( &mutex);
		}
		
		// [54]. SE PIDE QUE SE AVISE A LOS DEMAS JUGADORES DE LA PARTIDA DEL MOVIMIENTO DE UNA FICHA.
		// Se recibe con el formato: '54/Marc-1/numFicha|PosX|PosY'
		// Se envia con el formato: '54/numFicha|PosX|PosY'
		else if (codigo == 54)
		{
			pthread_mutex_lock( &mutex);
			
			char userIDP[100];// "user-IDP"
			p = strtok(NULL, "/");
			strcpy(userIDP, p);
			
			char missatge[500];
			p = strtok(NULL, "/"); // "numFicha|PosX|PosY"
			sprintf(missatge, "54/%s", p); // Enviará a los clientes el mensaje: "54/numFicha|PosX|PosY"
			printf ("<--- Respuesta: %s\n",missatge); 
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * MECANISMO DE REENVIO A LOS JUGADORES DE LA MISMA PARTIDA * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			char quienEnvia[20];
			char *q = strtok(userIDP, "-");
			strcpy(quienEnvia,q);
			printf(">>> QUIEN ENVIA: %s\n", quienEnvia);
			q = strtok(NULL, "-");
			int idMiPartida = atoi(q);
			printf(">>> PARTIDA DEL QUE ENVIA: %d\n", idMiPartida);
			int PosMiPartida = DamePosicionPartida(&listaPartidas, idMiPartida);
			printf(">>> POSICION DE LA PARTIDA DEL QUE ENVIA: %d\n", PosMiPartida);
			int otrosSockets[MAX_JUGADORES];
			for (int i=0;i<MAX_JUGADORES;i++)
			{
				char nombreJugador[20];
				strcpy(nombreJugador, listaPartidas.partidas[PosMiPartida].jugador[i].nombre);
				if (strcmp(nombreJugador,quienEnvia)==0) {
					otrosSockets[i]=-1;
				}
				else {
					otrosSockets[i]=DameSocket(&miLista,nombreJugador);
				}
				printf(">>> SE AÑADE EL SOCKET A REENVIAR %d\n", otrosSockets[i]);
			}
			for (int j=0; j<4; j++) { // SE RESPONDE A LOS OTROS DE LA PARTIDA	
				if (otrosSockets[j]!=-1) // Si no es el socket del que ha hecho la petición ...
				{
					write (otrosSockets[j], missatge, strlen(missatge));
					printf ("ENVIA '%s' al socket '%d'.\n",missatge, otrosSockets[j]);
				}
			}
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			
			pthread_mutex_unlock( &mutex);
		}
		
		// [58]. SE ACTUALIZA EL DINERO DE LOS DEMAS JUGADORES DE LA PARTIDA.
		// Se recibe con el formato: '58/Marc-1/numFicha|dinero'
		// Se envia con el formato: '58/numFicha|dinero'
		else if (codigo == 58)
		{
			pthread_mutex_lock( &mutex);
			
			char userIDP[100];// "user-IDP"
			p = strtok(NULL, "/");
			strcpy(userIDP, p);
			
			char missatge[500];
			p = strtok(NULL, "/"); // "numFicha|dinero"
			sprintf(missatge, "58/%s", p);
			printf ("<--- Respuesta: %s\n",missatge); 
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * MECANISMO DE REENVIO A LOS JUGADORES DE LA MISMA PARTIDA * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			char quienEnvia[20];
			char *q = strtok(userIDP, "-");
			strcpy(quienEnvia,q);
			printf(">>> QUIEN ENVIA: %s\n", quienEnvia);
			q = strtok(NULL, "-");
			int idMiPartida = atoi(q);
			printf(">>> PARTIDA DEL QUE ENVIA: %d\n", idMiPartida);
			int PosMiPartida = DamePosicionPartida(&listaPartidas, idMiPartida);
			printf(">>> POSICION DE LA PARTIDA DEL QUE ENVIA: %d\n", PosMiPartida);
			int otrosSockets[MAX_JUGADORES];
			for (int i=0;i<MAX_JUGADORES;i++)
			{
				char nombreJugador[20];
				strcpy(nombreJugador, listaPartidas.partidas[PosMiPartida].jugador[i].nombre);
				if (strcmp(nombreJugador,quienEnvia)==0) {
					otrosSockets[i]=-1;
				}
				else {
					otrosSockets[i]=DameSocket(&miLista,nombreJugador);
				}
				printf(">>> SE AÑADE EL SOCKET A REENVIAR %d\n", otrosSockets[i]);
			}
			for (int j=0; j<4; j++) { // SE RESPONDE A LOS OTROS DE LA PARTIDA	
				if (otrosSockets[j]!=-1) // Si no es el socket del que ha hecho la petición ...
				{
					write (otrosSockets[j], missatge, strlen(missatge));
					printf ("ENVIA '%s' al socket '%d'.\n",missatge, otrosSockets[j]);
				}
			}
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			
			pthread_mutex_unlock( &mutex);
		}
		
		// [59]. SE ACTUALIZAN LOS CREDITOS DE LOS DEMAS JUGADORES DE LA PARTIDA.
		// Se recibe con el formato: '59/Marc-1/numFicha|creditos'
		// Se envia con el formato: '59/numFicha|creditos'
		else if (codigo == 59)
		{
			pthread_mutex_lock( &mutex);
			
			char userIDP[100];// "user-IDP"
			p = strtok(NULL, "/");
			strcpy(userIDP, p);
			
			char missatge[500];
			p = strtok(NULL, "/"); // "numFicha|creditos"
			sprintf(missatge, "59/%s", p);
			printf ("<--- Respuesta: %s\n",missatge); 
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * MECANISMO DE REENVIO A LOS JUGADORES DE LA MISMA PARTIDA * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			char quienEnvia[20];
			char *q = strtok(userIDP, "-");
			strcpy(quienEnvia,q);
			printf(">>> QUIEN ENVIA: %s\n", quienEnvia);
			q = strtok(NULL, "-");
			int idMiPartida = atoi(q);
			printf(">>> PARTIDA DEL QUE ENVIA: %d\n", idMiPartida);
			int PosMiPartida = DamePosicionPartida(&listaPartidas, idMiPartida);
			printf(">>> POSICION DE LA PARTIDA DEL QUE ENVIA: %d\n", PosMiPartida);
			int otrosSockets[MAX_JUGADORES];
			for (int i=0;i<MAX_JUGADORES;i++)
			{
				char nombreJugador[20];
				strcpy(nombreJugador, listaPartidas.partidas[PosMiPartida].jugador[i].nombre);
				if (strcmp(nombreJugador,quienEnvia)==0) {
					otrosSockets[i]=-1;
				}
				else {
					otrosSockets[i]=DameSocket(&miLista,nombreJugador);
				}
				printf(">>> SE AÑADE EL SOCKET A REENVIAR %d\n", otrosSockets[i]);
			}
			for (int j=0; j<4; j++) { // SE RESPONDE A LOS OTROS DE LA PARTIDA	
				if (otrosSockets[j]!=-1) // Si no es el socket del que ha hecho la petición ...
				{
					write (otrosSockets[j], missatge, strlen(missatge));
					printf ("ENVIA '%s' al socket '%d'.\n",missatge, otrosSockets[j]);
				}
			}
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			
			pthread_mutex_unlock( &mutex);
		}
		
		// [61]. SE ACTUALIZAN LOS PROPIETARIOS DE LAS CASILLAS.
		// Se recibe con el formato: '61/user-idGame/user|idPosOwners'
		// Se envia con el formato: '61/user|idPosOwners'
		else if (codigo == 61)
		{
			pthread_mutex_lock( &mutex);
			
			char userIDP[100];// "user-IDP"
			p = strtok(NULL, "/");
			strcpy(userIDP, p);
			
			char missatge[500];
			p = strtok(NULL, "/"); // "user|idPosOwners"
			sprintf(missatge, "61/%s", p);
			printf ("<--- Respuesta: %s\n",missatge); 
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * MECANISMO DE REENVIO A LOS JUGADORES DE LA MISMA PARTIDA * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			char quienEnvia[20];
			char *q = strtok(userIDP, "-");
			strcpy(quienEnvia,q);
			printf(">>> QUIEN ENVIA: %s\n", quienEnvia);
			q = strtok(NULL, "-");
			int idMiPartida = atoi(q);
			printf(">>> PARTIDA DEL QUE ENVIA: %d\n", idMiPartida);
			int PosMiPartida = DamePosicionPartida(&listaPartidas, idMiPartida);
			printf(">>> POSICION DE LA PARTIDA DEL QUE ENVIA: %d\n", PosMiPartida);
			int otrosSockets[MAX_JUGADORES];
			for (int i=0;i<MAX_JUGADORES;i++)
			{
				char nombreJugador[20];
				strcpy(nombreJugador, listaPartidas.partidas[PosMiPartida].jugador[i].nombre);
				if (strcmp(nombreJugador,quienEnvia)==0) {
					otrosSockets[i]=-1;
				}
				else {
					otrosSockets[i]=DameSocket(&miLista,nombreJugador);
				}
				printf(">>> SE AÑADE EL SOCKET A REENVIAR %d\n", otrosSockets[i]);
			}
			for (int j=0; j<4; j++) { // SE RESPONDE A LOS OTROS DE LA PARTIDA	
				if (otrosSockets[j]!=-1) // Si no es el socket del que ha hecho la petición ...
				{
					write (otrosSockets[j], missatge, strlen(missatge));
					printf ("ENVIA '%s' al socket '%d'.\n",missatge, otrosSockets[j]);
				}
			}
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			
			pthread_mutex_unlock( &mutex);
		}
		
		// [77]. EL JUGADOR 1 DE UNA PARTIDA NOS DICE QUE SE HA ACABADO SU PARTIDA.
		// Se recibe con el formato: '77/Marc-1/nomP1|cP1|nomP2|cP2|nomP3|cP3|nomP4|cP4'
		// Se envia con el formato: '77/nomP1|cP1|nomP2|cP2|nomP3|cP3|nomP4|cP4'
		else if (codigo == 77)
		{
			pthread_mutex_lock( &mutex);
			
			char userIDP[100];// "user-IDP"
			p = strtok(NULL, "/");
			strcpy(userIDP, p);
			
			char missatge[500];
			p = strtok(NULL, "/"); // "nomP1|cP1|nomP2|cP2|nomP3|cP3|nomP4|cP4"
			sprintf(missatge, "77/%s", p);
			printf ("<--- Respuesta: %s\n",missatge); 
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * MECANISMO DE REENVIO A LOS JUGADORES DE LA MISMA PARTIDA * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			char quienEnvia[20];
			char *q = strtok(userIDP, "-");
			strcpy(quienEnvia,q);
			printf(">>> QUIEN ENVIA: %s\n", quienEnvia);
			q = strtok(NULL, "-");
			int idMiPartida = atoi(q);
			printf(">>> PARTIDA DEL QUE ENVIA: %d\n", idMiPartida);
			int PosMiPartida = DamePosicionPartida(&listaPartidas, idMiPartida);
			printf(">>> POSICION DE LA PARTIDA DEL QUE ENVIA: %d\n", PosMiPartida);
			int otrosSockets[MAX_JUGADORES];
			for (int i=0;i<MAX_JUGADORES;i++)
			{
				// EN ESTE CASO, QUEREMOS QUE LO REENVIE A TODOS LOS DE LA PARTIDA, INCLUIDO EL QUE LO PIDE:
				char nombreJugador[20];
				strcpy(nombreJugador, listaPartidas.partidas[PosMiPartida].jugador[i].nombre);
				otrosSockets[i]=DameSocket(&miLista,nombreJugador);
				printf(">>> SE AÑADE EL SOCKET A REENVIAR %d\n", otrosSockets[i]);
			}
			for (int j=0; j<4; j++) { // SE RESPONDE A LOS OTROS DE LA PARTIDA	
				write (otrosSockets[j], missatge, strlen(missatge));
				printf ("ENVIA '%s' al socket '%d'.\n",missatge, otrosSockets[j]);
			}
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			
			pthread_mutex_unlock( &mutex);
		}
		
		// [85]. ELIMINAR UN JUGADOR DE LA BASE DE DATOS:
		// Se recibe con el formato: '85/username,'
		// No se debe reenviar nada.
		else if (codigo == 85)
		{	
			char username[100];// "username"
			p = strtok(NULL, ",");
			strcpy(username, p);
			
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// ACCEDEMOS A LA BBDD PARA ELIMINAR AL USUARIO:
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			
			MYSQL *conn;
			int err;
			MYSQL_RES *resultado;
			MYSQL_ROW row;
			conn = mysql_init(NULL);
			if (conn==NULL) {
				printf ("Error al crear la conexion: %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			// conn = mysql_real_connect (conn, "localhost","root", "mysql", "Diez",0, NULL, 0);
			conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T10_BBDD",0, NULL, 0);
			if (conn==NULL) {
				printf ("Error al inicializar la conexion: %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			char mensaje[1000];
			// "DELETE FROM Jugador WHERE (usuario='');"
			strcpy(mensaje, "DELETE FROM Jugador WHERE (usuario='");
			strcat(mensaje, username);
			strcat(mensaje, "');");
			err = mysql_query (conn, mensaje);
			if (err!=0)
			{
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			else
			{
				printf("¡Valores Introducidos!\n");
			}
			mysql_close(conn);
		}
		
		// [97]. GUARDAR PARTICIPACION DE UN JUGADOR:
		// Se recibe con el formato: '97/ganador-fecha-username-creditos,'
		// No se debe reenviar nada.
		else if (codigo == 97)
		{	
			char GFUC[100];// "ganador-fecha-username-creditos"
			p = strtok(NULL, ",");
			strcpy(GFUC, p);
			
			char ganador[100];
			char fecha[100];
			char username[100];
			int creditos;
			
			char *q = strtok(GFUC, "-");
			strcpy(ganador,q);

			q = strtok(NULL, "-");
			strcpy(fecha,q);
			
			q = strtok(NULL, "-");
			strcpy(username,q);
			
			q = strtok(NULL, "-");
			creditos = atoi(q);
			
			
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// ACCEDEMOS A LA BASE DE DATOS PARA:
			// 1. ID PARTIDA.
			// 2. ID JUGADOR.
			// 3. INSERTAR PARTICIPACION.
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			
			MYSQL *conn;
			int err;
			MYSQL_RES *resultado;
			MYSQL_ROW row;
			conn = mysql_init(NULL);
			if (conn==NULL) {
				printf ("Error al crear la conexion: %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			// conn = mysql_real_connect (conn, "localhost","root", "mysql", "Diez",0, NULL, 0);
			conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T10_BBDD",0, NULL, 0);
			if (conn==NULL) {
				printf ("Error al inicializar la conexion: %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
		
			
			// 1. ID PARTIDA.
			// SELECT IDPartida FROM Partida WHERE (ganador='A3' and fecha='27/01/2022');
			char mensaje1[1000];
			strcpy(mensaje1, "SELECT IDPartida FROM Partida WHERE (ganador='");
			strcat(mensaje1, ganador);
			strcat(mensaje1, "' and fecha='");
			strcat(mensaje1, fecha);
			strcat(mensaje1, "');");
			err = mysql_query (conn, mensaje1);
			int idpart;
			resultado = mysql_store_result(conn);
			row = mysql_fetch_row(resultado);
			idpart = atoi(row[0]);
			printf(">>> IDPARTIDA: %d\n", idpart);
			
			// 2. ID JUGADOR.
			// SELECT IDJugador FROM Jugador WHERE (usuario='eeee');
			char mensaje2[1000];
			strcpy(mensaje2, "SELECT IDJugador FROM Jugador WHERE (usuario='");
			strcat(mensaje2, username);
			strcat(mensaje2, "');");
			err = mysql_query (conn, mensaje2);
			int idjug;
			resultado = mysql_store_result(conn);
			row = mysql_fetch_row(resultado);
			idjug = atoi(row[0]);
			printf(">>> IDJUGADOR: %d\n", idjug);
			
			// 3. INSERTAR PARTICIPACION.
			// INSERT INTO Participacion VALUES (idjug,idpart,creditos);
			char mensaje3[1000];
			sprintf(mensaje3, "INSERT INTO Participacion VALUES (%d,%d,%d);",idjug,idpart,creditos);
			err = mysql_query (conn, mensaje3);
			mysql_close(conn);
			
		}
		
		// [99]. SE GUARDA LA INFORMACIÓN DE UNA PARTIDA EN LA BASE DE DATOS.
		// Se recibe con el formato: '99/nombreGanador-FechaPartida,'
		// No se debe reenviar nada.
		else if (codigo == 99)
		{
			pthread_mutex_lock( &mutex);
			
			char nombreFecha[100];// "nombreGanador-FechaPartida"
			p = strtok(NULL, ",");
			strcpy(nombreFecha, p);
			
			char nombreGanador[50];
			char fechaPartida[50];
			char *q = strtok(nombreFecha, "-");
			strcpy(nombreGanador,q);
			printf(">>> GANADOR: %s\n", nombreGanador);
			q = strtok(NULL, "-");
			strcpy(fechaPartida,q);
			printf(">>> FECHA DE LA PARTIDA: %s\n", fechaPartida);
			
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// AQUI SE GUARDA ESTA PARTIDA EN LA BBDD.
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			
			MYSQL *conn;
			int err;
			MYSQL_RES *resultado;
			MYSQL_ROW row;
			conn = mysql_init(NULL);
			if (conn==NULL) {
				printf ("Error al crear la conexion: %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			// conn = mysql_real_connect (conn, "localhost","root", "mysql", "Diez",0, NULL, 0);
			conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T10_BBDD",0, NULL, 0);
			if (conn==NULL) {
				printf ("Error al inicializar la conexion: %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			char mensaje[1000];
			strcpy(mensaje, "INSERT INTO Partida(ganador,fecha) VALUES ('");
			strcat(mensaje, nombreGanador);
			strcat(mensaje, "','");
			strcat(mensaje, fechaPartida);
			strcat(mensaje, "');");
			err = mysql_query (conn, mensaje);
			if (err!=0)
			{
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			else
			{
				printf("¡Valores Introducidos!\n");
			}
			mysql_close(conn);
			
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
			
			pthread_mutex_unlock( &mutex);
		}
		
		// ACTUALIZACION DE LA LISTA DE CONECTADOS.
		if (codigo == 0 || codigo == 4) // Si bien alguien se desconecta (0) o se conecta (4), se actualiza la lista de conectados.
		{
			pthread_mutex_lock( &mutex);
			
			char notificacion[512];
			char conectados[512];
			DameConectados(&miLista, conectados);
			sprintf(notificacion,"6/%s\n",conectados);
			printf ("<--- Respuesta: %s \n",notificacion);
			printf ("\n");
			
			int j;
			for (j=0; j<miLista.num; j++) { // SE RESPONDE A LOS USUARIOS QUE CONVIENE.
				write (sockets[j], notificacion, strlen(notificacion));
			}
			
			pthread_mutex_unlock( &mutex);
		}
	}
	close(sock_conn);
}

// - - - - - - - - - - - - - - - - - - - - - - - MAIN - - - - - - - - - - - - - - - - - - - - - - - -

int main(int argc, char *argv[])
{
	miLista.num = 0;
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;

	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("¡Error creant socket!\n");
	
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	
	serv_adr.sin_port = htons(50081);
	// serv_adr.sin_port = htons(9011);
	
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("¡Error al bind!\n");
	
	if (listen(sock_listen, 3) < 0)
		printf("¡Error en el Listen!\n");
	
	pthread_t thread[100];
	
	for (NUM_CONECTADOS=0;NUM_CONECTADOS>-1;NUM_CONECTADOS++)
	{ // Bucle infinito (siempre escucha).
		printf ("¡Servidor ESCUCHANDO!\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("¡He recibido conexion!\n");
		sockets[NUM_CONECTADOS]=sock_conn;
		pthread_create(&thread[NUM_CONECTADOS], NULL, AtenderCliente, &sockets[NUM_CONECTADOS]);
		
	}
}

// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
