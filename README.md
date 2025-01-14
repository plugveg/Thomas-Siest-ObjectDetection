# Examen Microsoft Technologies 2025 - Thomas Siest
## Thomas-Siest-ObjectDetection

Ce projet est une implémentation de Object Detection en C#. Il contient :
- Une librairie pour détecter des objets dans des scènes.
- Une application console.
- Une API Web exposant les fonctionnalités.

## Lien GitHub
[Consultez le projet sur GitHub](https://github.com/plugveg/Thomas-Siest-ObjectDetection)

## Initiation de la solution (.sln) et création du projet librairie (3 points)
- Créer une solution (.sln) nommée `Thomas-Siest-ObjectDetection` via la commande `dotnet new sln -n Thomas.Siest.ObjectDetection`.
- Création du dossier src.
- Créer un projet librairie nommé `Thomas.Siest.ObjectDetection` via la commande `dotnet new classlib -n Thomas.Siest.ObjectDetection -o src/Thomas.Siest.ObjectDetection`.
- Ajouter le projet à la solution via la commande `dotnet sln add src/Thomas.Siest.ObjectDetection`.
- Création des 2 fichiers `ObjectDetection.cs` et `ObjectDetectionResult.cs` dans le projet librairie.
- Créer un fichier README.md à la racine du projet.
- Ajouter le gitignore via la commande `dotnet new gitignore`.

## Création d’un projet de test unitaire (4 points) 
- Création du dossier tests.
- Créer un projet de test unitaire nommé `Thomas.Siest.ObjectDetection.Tests` via la commande `dotnet new xunit -n Thomas.Siest.ObjectDetection.Tests -o tests/Thomas.Siest.ObjectDetection.Tests`.
- Ajouter le projet à la solution via la commande `dotnet sln add tests/Thomas.Siest.ObjectDetection.Tests`.
- Ajouter une référence vers le projet `Thomas.Siest.ObjectDetection` via la commande `dotnet add tests/Thomas.Siest.ObjectDetection.Tests reference src/Thomas.Siest.ObjectDetection`.
- Création du fichier `ObjectDetectionUnitTest.cs` dans le projet de test unitaire.
- Ajout du dossier `Scenes` avec les images de scènes à tester sous le nom `Thomas-Siest-scene-0.jpg` et `Thomas-Siest-scene-1.jpg`.
  - Ne pas oublier de copier les images dans le dossier de sortie du projet de test unitaire via le fichier `Thomas.Siest.ObjectDetection.Tests.csproj`.
  - Exemple :
  ```xml
    <ItemGroup>
    <None Update="Scenes\Thomas-Siest-scene-0.jpg">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
    <None Update="Scenes\Thomas-Siest-scene-1.jpg">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>
    ```
  - PS: On peut aussi le faire via l'interface graphique de Rider (comme expliqué dans l'énoncé).
- 