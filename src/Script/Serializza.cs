﻿using System;
using Newtonsoft.Json;

public class Serializza
{
    public static void Main(string[] args)
    {
        /*test da rimuovere
        List <Piatto> var = Serializza.leggiOggettiDaFile<Piatto> (@"C:\Users\alex1\Desktop\Healthy-Catering\src\Database\Piatto.json");
        Console.WriteLine (var[0].nome);
        foreach (OggettoQuantita<int> i in var [0].ingredienti){
            Console.WriteLine (i.oggetto); //poi ci sarebbe da chiamare la funzione da idIngrediente a ingrediente ma vabz 
        }
        */
        
    }

    public static void salvaOggettiSuFile <Oggetto> (List <Oggetto> oggetti)
    {
        if (oggetti.Count > 0){
            string pathJson = Directory.GetCurrentDirectory() + @"\..\Database\" + oggetti[0].GetType().Name + ".json";
            using (StreamWriter file = File.CreateText(@pathJson))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, oggetti);
            }
        }
        else{
            throw new InvalidOperationException("Lista passata vuota, progressi non salvati (?)");
        }

        /*
        Esempio di utilizzo:
            List <Dieta> diete = new List<Dieta> ();
            diete.Add (new Dieta ("1"));
            diete.Add (new Dieta ("2"));
            try{
                Serializza.salvaOggettiSuFile<Dieta> (diete);
            }
            catch (InvalidOperationException e){
                Console.WriteLine (e.Message);
            }
        */
    }

    public static List<Oggetto> leggiOggettiDaFile <Oggetto> (string filePath)
    {
        if (File.Exists(filePath)){
            string json = File.ReadAllText(@filePath);
            return JsonConvert.DeserializeObject<List<Oggetto>>(json);
        }
        else{
            throw new FileNotFoundException ("File non trovato, salva un salvataggio di una lista della classe che mi stai passando per leggerla!");
        }

        /*
        Esempio di utilizzo:
            try{
                List <Dieta> idk = Serializza.leggiOggettiDaFile<Dieta> (@"C:\Users\alex1\Desktop\Healthy-Catering\progetto\Healthy Catering\Assets\Script\prova serializza\Dieta.json");
                foreach (var dieta in idk){
                    Console.WriteLine (dieta);
                }
            }
            catch (FileNotFoundException e){
                Console.WriteLine (e.Message);
            }
        */
    }

    /*
    La classe Cliente utilizzata negli esempi:
        public class Dieta
        {
            public string nome = "";

            public Dieta(string nome)
            {
                this.nome = nome;
            }

            public override string ToString()
            {
                return nome;
            }
        }
    */

    private static void creaDatabaseBase (){
        Serializza.creaDatabaseBaseCliente ();
        Serializza.creaDatabaseBaseDieta ();
        Serializza.creaDatabaseBaseIngrediente ();
        Serializza.creaDatabaseBasePatologia ();
        Serializza.creaDatabaseBasePiatto ();
        Serializza.creaDatabaseBasePlayer ();
        Serializza.creaDatabaseBaseRistorante ();
    }

    private static void creaDatabaseBaseCliente (){
        //Cliente
        List <Cliente> tempCliente = new List<Cliente> ();
        
        List <int> tempClienteListaIdPatologie = new List<int> ();
        tempClienteListaIdPatologie.Add(0);
        tempClienteListaIdPatologie.Add(1);
        
        tempCliente.Add(new Cliente ("", 0, tempClienteListaIdPatologie));
        tempCliente.Add(new Cliente ("", 0, tempClienteListaIdPatologie));

        Serializza.salvaOggettiSuFile <Cliente> (tempCliente);
    }

    private static void creaDatabaseBaseDieta (){
        //Dieta
        List <Dieta> tempDieta = new List<Dieta> ();
        
        tempDieta.Add(new Dieta ("", ""));
        tempDieta.Add(new Dieta ("", ""));

        Serializza.salvaOggettiSuFile <Dieta> (tempDieta);
    }

    private static void creaDatabaseBaseIngrediente (){
        //Ingrediente
        List <Ingrediente> tempIngrediente = new List<Ingrediente> ();

        List <int> listaIdPatologieCompatibili = new List <int> ();
        listaIdPatologieCompatibili.Add(-1);
        listaIdPatologieCompatibili.Add(-1);        

        tempIngrediente.Add(new Ingrediente (-1, "", "", 0, 0, 0, 0, listaIdPatologieCompatibili));
        tempIngrediente.Add(new Ingrediente (-1, "", "", 0, 0, 0, 0, listaIdPatologieCompatibili));

        Serializza.salvaOggettiSuFile <Ingrediente> (tempIngrediente);
    }

    private static void creaDatabaseBasePatologia (){
        //Patologia
        List <Patologia> tempPatologia = new List<Patologia> ();
        
        tempPatologia.Add(new Patologia (-1, "", ""));
        tempPatologia.Add(new Patologia (-1, "", ""));

        Serializza.salvaOggettiSuFile <Patologia> (tempPatologia);
    }

    private static void creaDatabaseBasePiatto (){
        //Piatto
        List <Piatto> tempPiatto = new List<Piatto> ();
        
        List <OggettoQuantita <int>> tempPiattoListaIngredienti = new List<OggettoQuantita<int>> ();
        tempPiattoListaIngredienti.Add (new OggettoQuantita<int> (-1, 0));
        tempPiattoListaIngredienti.Add (new OggettoQuantita<int> (-1, 0));
        
        tempPiatto.Add(new Piatto ("", "", 0, 0, 0, tempPiattoListaIngredienti));
        tempPiatto.Add(new Piatto ("", "", 0, 0, 0, tempPiattoListaIngredienti));

        Serializza.salvaOggettiSuFile <Piatto> (tempPiatto);
    }

    private static void creaDatabaseBasePlayer (){
        //Player
        List <Player> tempPlayer = new List<Player> ();
        
        List <OggettoQuantita<Item>> tempPlayerInventario = new List <OggettoQuantita<Item>> ();
        tempPlayerInventario.Add(new OggettoQuantita<Item> (new Item (-1, "", ""), 0));
        tempPlayerInventario.Add(new OggettoQuantita<Item> (new Item (-1, "", ""), 0));
        
        tempPlayer.Add(new Player ("", 0, tempPlayerInventario));
        tempPlayer.Add(new Player ("", 0, tempPlayerInventario));

        Serializza.salvaOggettiSuFile <Player> (tempPlayer);
    }

    private static void creaDatabaseBaseRistorante (){
    //Ristorante
        List <Ristorante> tempRistorante = new List<Ristorante> ();
        
        List <int> listaIdPatologieCompatibili = new List <int> ();
        listaIdPatologieCompatibili.Add(-1);
        listaIdPatologieCompatibili.Add(-1);   

        List <OggettoQuantita <Ingrediente>> tempRistorateMagazzinoIngredienti = new List<OggettoQuantita<Ingrediente>> ();
        tempRistorateMagazzinoIngredienti.Add (new OggettoQuantita<Ingrediente> (new Ingrediente (-1, "", "", 0, 0, 0, 0, listaIdPatologieCompatibili), 0));
        tempRistorateMagazzinoIngredienti.Add (new OggettoQuantita<Ingrediente> (new Ingrediente (-1, "", "", 0, 0, 0, 0, listaIdPatologieCompatibili), 0));
        
        tempRistorante.Add(new Ristorante ("", 0, tempRistorateMagazzinoIngredienti));
        tempRistorante.Add(new Ristorante ("", 0, tempRistorateMagazzinoIngredienti));

        Serializza.salvaOggettiSuFile <Ristorante> (tempRistorante);
    }
}
