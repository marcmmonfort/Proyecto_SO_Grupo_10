﻿// - - - - - - - - - - - LIBRARY - - - - - - - - - - -

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

// - - - - - - - - - - - FUNCTIONS - - - - - - - - - - -

// #0. ESTRUCTURAS. - - - - -

typedef struct {
	char nombre [20];
	int socket;
} Conectado;

typedef struct {
	Conectado conectados [100];
	int num;
} ListaConectados;

ListaConectados miLista;
pthread_mutex_t mutex= PTHREAD_MUTEX_INITIALIZER;

// #A. PON USUARIO EN LISTA DE CONECTADOS. - - - - -

int Pon (ListaConectados *lista,char nombre[20],int socket){
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

// #B. DAME POSICION EN LA LISTA DE CONECTADOS. - - - - -

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

// #C. PON USUARIO EN LISTA DE CONECTADOS. - - - - -

int DameSocket (ListaConectados *lista, char nombre[20]){
	//Devuelve el socket o -1 si no esta en la lista
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

// #D. ELIMINAR UN JUGADOR DE LA LISTA DE CONECTADOS CUANDO DEJE DE JUGAR. - - - - -

int Eliminar (ListaConectados *lista,char nombre[20])
{
	int pos = DamePosicion (lista,nombre);
	if (pos==-1)
		return -1;
	else{
		int i;
		for (i=pos;i<lista->num -1;i++)
		{
			lista->conectados[i]=lista->conectados[i+1];
		}
		lista->num--;
		return 0;
	}
}

// #E. RELLENA UN VECTOR CON EL NOMBRE DE CONECTADOS. - - - - -

void DameConectados (ListaConectados *lista,char conectados[300])
{
	sprintf(conectados,"%d",lista->num);
	int i;
	for (i=0;i<lista->num;i++)
		sprintf(conectados,"%s/%s",conectados,lista->conectados[i].nombre);
}

// #1. CONSULTA EL NÚMERO DE PARTIDAS DE UN JUGADOR. - - - - -

int NumPartidas(char nombre[50]) {
	
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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Diez",0, NULL, 0);
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
	// exit(0);
	
	return partidas;
}

// #2. CONSULTA EL NÚMERO DE CRÉDITOS DEL GANADOR DE UNA PARTIDA EN UNA FECHA CONCRETA. - - - - -

int SumaCreditos(char ganador[50], char fecha[50]) {
	
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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Diez",0, NULL, 0);
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

// #3. ELOI. - - - - -

int GanadorContra(char nombre[50], char * perdedores){
	
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	conn = mysql_init(NULL);
	
	if (conn==NULL) {
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Diez",0, NULL, 0);
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
		strcpy (perdedores, "\0");
	
		while (row != NULL){
			strcat (perdedores, "\n");
			strcat (perdedores, row[0]);
			row = mysql_fetch_row(resultado);
			
		}
	}		
	
	mysql_close(conn);
	return 0;
	
}

// #4. LOGIN. - - - - -

// Si existe el usuario, y la contraseña es la correcta, entonces devuelve 0.
// Si no, devuelve -1.

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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Diez",0, NULL, 0);
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
		printf ("No se han obtenido datos en la consulta\n");
	else {
		strcpy(contraVerdadera,row[0]);
	}
	
	mysql_close(conn);
	// exit(0);
		
	if (strcmp(contraVerdadera, contra) == 0)
	{
		return 0;
	}
	else
	{
		return -1;
	}
}

// #5. REGISTER. - - - - -
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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Diez",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	char mensaje[1000];
	strcpy(mensaje, "INSERT INTO Jugador(usuario,contra) VALUES ('");
	strcat(mensaje, nombre);
	strcat(mensaje, "','");
	strcat(mensaje, contra);
	strcat(mensaje, "');");
	
	err = mysql_query (conn, mensaje);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	mysql_close(conn);
	// exit(0);
}
// FUNCIÓN PARA ATENDER A UN CLIENTE. - - - - -

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
	// Entramos en un bucle para atender todas las peticiones de este cliente hasta que se desconecte
	while (terminar == 0)
	{
			
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		peticion[ret]='\0';	
		printf ("Peticion: %s\n",peticion);
		
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p); // Número de petición.
			
		if (codigo == 0)
		{
			terminar = 1;	
			// Ponemos en 'nombre' el nombre del usuario que pregunta.				
			char nombre[50];
			p = strtok( NULL, "/");
			strcpy (nombre, p);	
			Eliminar (&miLista, nombre);
		}
			
		else if (codigo ==1) // PETICIÓN DE ALBA.
		{
			pthread_mutex_lock( &mutex);
			// Ponemos en 'ganador' el nombre del usuario que pregunta.	
			char ganador[50];
			p = strtok( NULL, "/");
			strcpy (ganador, p);				
			//Ponemos en 'fecha' la fecha de la partida.	
			char fecha[50];
			p = strtok(NULL, ".");
			strcpy (fecha, p);
			int sumCreditos = SumaCreditos(ganador, fecha);
			
			char answer[20];
			sprintf(answer, "%d", sumCreditos);
			strcpy (respuesta,answer); // Devuelve el número de créditos como respuesta.
			pthread_mutex_unlock( &mutex);
		}
		
		else if (codigo ==2) // PETICIÓN DE MARC.
		{
			printf("Petcion 2 recibida");
			pthread_mutex_lock( &mutex);
			// Ponemos en 'nombre' el nombre del usuario que pregunta.				
			char nombre[50];
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			
			int partidas = NumPartidas(nombre);
			
			char answer[20];
			sprintf(answer, "%d", partidas);
			strcpy (respuesta,answer); // Devuelve el número de partidas como respuesta.
			pthread_mutex_unlock( &mutex);
		}
			
		else if (codigo ==3) // PETICIÓN DE ELOI.
		{
			pthread_mutex_lock( &mutex);
			char nombre[50];
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			
			char perdedores [512];
			strcpy (perdedores, "\0");
			int ret = GanadorContra(nombre, perdedores);
			strcpy (respuesta,perdedores); // Devuelve la lista de jugadores que han perdido contra el usuario seleccionado.
			pthread_mutex_unlock( &mutex);
		}
			
		else if (codigo ==4) // PETICIÓN LOGIN.
		{
			pthread_mutex_lock( &mutex);
			// Ponemos en 'nombre' el nombre del usuario que pregunta.				
			char nombre[50];
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			
			char contrasena[50];
			p = strtok( NULL, "/");
			strcpy (contrasena, p);
			
			int verificar = CheckPassword(nombre,contrasena);
				
			char answer[20];
			sprintf(answer, "%d", verificar);
			strcpy (respuesta,answer);
			pthread_mutex_unlock( &mutex);
				
			if (miLista.num <=100)
			{
				miLista.num=miLista.num + 1;
				Pon (&miLista, nombre, miLista.num);
			}
			
		}
			
		else if (codigo ==5) // PETICIÓN REGISTER.
		{
			pthread_mutex_lock( &mutex);
			char nombre[50];
			p = strtok( NULL, "/");
			strcpy (nombre, p);
				
			char contrasena[50];
			p = strtok( NULL, "/");
			strcpy (contrasena, p);
				
			int registrar = Register(nombre,contrasena);
				
			char answer[20];
			sprintf(answer, "%d", registrar);
			strcpy (respuesta,answer);
			pthread_mutex_unlock( &mutex);
		}
			
		else if (codigo==6)	// PETICIÓN LISTACONECTADOS.
		{
			pthread_mutex_lock( &mutex);
			DameConectados(&miLista,respuesta);//me da una cadena de caracteres separados por / empezando por el numero de conectados y luego el nombre de conectados
			char copia [512];
			char *p=strtok(respuesta,"/");
			int numconectados= atoi(p); //cogemos el nu￺mero de conectados
			sprintf(copia,"%d/",numconectados-1);
			p=strtok(NULL,"/");//misma rutina de strtok para ir separando los nombres que siguen el mismo patr￳n de orden en la char respuesta
			while (p!=NULL)
			{
				strcat(copia,p);
				strcat (copia,"/");
				p=strtok(NULL,"/");
					
			}
			strcpy(respuesta,copia);		
			pthread_mutex_unlock( &mutex);
		}
			
		if (codigo != 0)
		{
			printf ("Respuesta: %s\n", respuesta);
			write (sock_conn,respuesta, strlen(respuesta));
		}
		
		
		
		
		printf ("Respuesta: %s\n", respuesta);
		// Enviamos respuesta
		write (sock_conn,respuesta, strlen(respuesta));
	}
	close(sock_conn);
	//mysql_close (conn);
	//exit(0);
}


// - - - - - - - - - - - MAIN - - - - - - - - - - -

int main(int argc, char *argv[])
{
	
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;

	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(9016);
	
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	int i;
	int sockets[100];
	pthread_t thread[100];
	
	for (i=0;i<100;i++)
	{ // Bucle infinito (siempre escucha).
		printf ("Escuchando\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		sockets[i]=sock_conn;
		
		pthread_create(&thread[i], NULL, AtenderCliente, &sockets[i]);
		
	}
	
}

