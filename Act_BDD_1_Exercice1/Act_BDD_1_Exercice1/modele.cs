using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;


namespace Act_BDD_1_Exercice1
{
    public struct modele
    {
        public string DefinirCheminBD()
        {
            string CheminBDRelatif = System.IO.Directory.GetCurrentDirectory() + "\\Comptoirs.accdb";
            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + CheminBDRelatif;
        }

        public bool ChercherSociete(DataSet donneeResult)
        {
            // Déclaration et instanciation d’un objet de connexion en utilisant le chemin
            OleDbConnection maConnexion = new OleDbConnection(DefinirCheminBD());
            bool ok = false;
            try{
                maConnexion.Open();

                // déclaration et instanciation du dataAdapter avec la connexion et la requête
                OleDbDataAdapter da = new OleDbDataAdapter(query, maConnexion);

                // Remplissage du dataSet, “mesDonnees” est le nom attribué au contenu du dataSet
                da.Fill(donneeResult, "mesDonnees");

                // on peut accéder au données du dataSet avec la syntaxe suivante : 
                donneeResult.Tables[0].Rows[0]["nomDuChamp"];

                // déterminer le nombre de lignes se trouvant dans le dataSet : 
                donneeResult.Tables[0].Rows.Count;

                // fermeture de la connexion
                maConnexion.Close();
            }
            catch (Exception ex){
                Debug.WriteLine(ex.Message);
                throw;
            }

            return true;
        }
    }
}
