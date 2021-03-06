package com.educaciencia.consumer;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;

public class ConsumerJava {


	public static void main(String[] args) {

		//insertAPIJava();// Endppoint Post
		getAPIJava(); // Endpoioint Get
		//getIdAPIJava();// Endpoiint Get Id
		//updateAPIJava();// Endpoint Update

	}

	/**************************
	 * ***** MOCK API *********
	 **************************/

	public static void getAPIJava() {
		try {

			String endpointAPIJava = "http://localhost:8080/api/JPA/clientes/";

			URL url = new URL(endpointAPIJava);
			HttpURLConnection conn = (HttpURLConnection) url.openConnection();
			conn.setRequestMethod("GET");
			if (conn.getResponseCode() == 200) {
				System.out.print("HTTP code : " + conn.getResponseCode());
			} else {
				System.out.print("deu erro... HTTP error code : " + conn.getResponseCode());
			}

			BufferedReader br = new BufferedReader(new InputStreamReader((conn.getInputStream())));

			String output, json = "";
			while ((output = br.readLine()) != null) {
				json += output;
			}
			System.out.println("\nResult: " + json);

			conn.disconnect();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public static void getIdAPIJava() {
		try {

			String id = "1";
			String endpointAPIJava = "http://localhost:8080/api/JPA/clientes/" + id;

			URL url = new URL(endpointAPIJava);
			HttpURLConnection conn = (HttpURLConnection) url.openConnection();
			conn.setRequestMethod("GET");
			if (conn.getResponseCode() == 200) {
				System.out.println("HTTP code : " + conn.getResponseCode());
			} else {
				System.out.println("HTTP error code : " + conn.getResponseCode());
			}

			BufferedReader br = new BufferedReader(new InputStreamReader((conn.getInputStream())));

			String output, json = "";
			while ((output = br.readLine()) != null) {
				json += output;
			}
			System.out.println("\n"+json);

			conn.disconnect();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public static void insertAPIJava() {
		try {

			String endpointAPIJava = "http://127.0.0.1:8080/api/JPA/clientes/add/";

			URL url = new URL(endpointAPIJava);
			HttpURLConnection conn = (HttpURLConnection) url.openConnection();
			conn.setDoOutput(true);
			conn.setRequestMethod("POST");
			conn.setRequestProperty("Content-Type", "application/json");

			String json = 
					"{"
					+ "\"nome\":\"testeinsertAPI\","
					+ "\"email\":\"teste@teste.com.br\""
					+ "}";
			OutputStream os = conn.getOutputStream();
			os.write(json.getBytes());
			os.flush();

			BufferedReader br = new BufferedReader(new InputStreamReader((conn.getInputStream())));
			if (conn.getResponseCode() == 200) {
				String output;
				while ((output = br.readLine()) != null) {
					System.out.println(output);
					System.out.println("HTTP code : " + conn.getResponseCode());
				}
			} else {
				System.out.println("HTTP error code : " + conn.getResponseCode());
			}
			conn.disconnect();
		} catch (Exception e) {
			e.printStackTrace();
		}

	}

	public static void updateAPIJava() {
		try {

			String id = "1";
			String endpointAPIJava = "http://localhost:8080/api/JPA/clientes/" + id;

			URL url = new URL(endpointAPIJava);
			HttpURLConnection conn = (HttpURLConnection) url.openConnection();
			conn.setDoOutput(true);
			conn.setRequestMethod("PUT");
			conn.setRequestProperty("Content-Type", "application/json");

			String input = "{\"id\":"+id+ ",\"nome\":\"testeUPDATE\",\"email\":\"UPDATE\"}";
			// System.out.println(input);
			OutputStream os = conn.getOutputStream();
			os.write(input.getBytes());
			os.flush();

			BufferedReader br = new BufferedReader(new InputStreamReader((conn.getInputStream())));

			String output;
			System.out.println("Update from Server .... \n");
			while ((output = br.readLine()) != null) {
				System.out.println("\n" + output);
			}

			conn.disconnect();

		} catch (Exception e) {
			e.printStackTrace();
		}

	}

}
