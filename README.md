# Case-oppgave for GET IT-studentenes inneuke i august 2020

Målet med denne uken er å studere og forstå en eksempel-applikasjon som Terje har laget. 
Det er krevende å sette seg inn i eksisterende kode, men det er også veldig lærerikt!

Applikasjonen dere skal jobbe med er basert på en idé som Christoffer Hellenes hadde; han
ønsket en app som foreslår hva han skal ha på seg ut fra værmeldingen.

Terje er tilgjengelig mandag og fredag, men dagene i mellom er tanken at dere jobber selvstendig og individuelt med dette; samtidig som dere hjelper hverandre og deler kunnskapen dere har og får. 

Vurder alltid om oppgaven du ser på gir utbytte for deg. Om den er for lett eller for vanskelig, er det bedre å velge noe annet. Overordnet er ideen å sette seg inn i denne applikasjonen og lære av det. En måte å få til det på er ved å gjøre små endringer. I tillegg til det som er under, kan dere finner på små endringer å gjøre selv - om forslagene under ikke passer.

## Oppgaver

1. Last ned og test applikasjonen. 
   1. Last ned fra [github.com/GetAcademy/NeverBadWeather](https://github.com/GetAcademy/NeverBadWeather). 
   1. Lag en lokal database.
   1. Kjør skriptet **CreateDb.sql** som du finner i prosjektet **NeverBadWeather.Infrastructure.DataAccess**.
   1. Pass på at connection stringen i **appsettings.json** peker på _din_ database.
   1. Kjør applikasjonen og utforsk hva den gjør. 
1. Bruk det å tegne opp sekvensdiagrammer til å visualisere logikken i denne applikasjonen. 
    1. Bruk [www.websequencediagrams.com](https://www.websequencediagrams.com/) til å lage et sekvensdiagram av metoden `GetClothingRecommendation()` i `ClothingRecommendationService`.
1. Bruk unit testing til å forstå hva som skjer i **DomainModel** i **Core**. Husk at om du lurer på hvordan klassen og metoden du tester skal brukes, så finnes svaret i eksisterende kode. Du kan også kjøre applikasjonen i debug-modus og steppe deg gjennom koden for å forstå hva som skjer. 
    1. En enkel klasse å begynne med er **Location**. Det finnes alt en unit test av denne, som tester at metoden `IsWithin()` returnerer `true` når den skal. Lag en ny test som sjekker at den også returnerer `false` når den skal, samt tilsvarende tester for de andre metodene i klassen. 
    1. Lag unit tester for en eller flere av disse klassene: 
       -  `PlaceList`
       -  `WeatherForecast` 
       -  `TemperatureStatistics`
       -  `ClothingRule`
1. Bruk unit testing til å forstå hva som skjer i **ApplicationServices** i **Core**. 
   1. En relativt enkel oppgave er å unit teste `CreateOrUpdateRule()`  i `ClothingRecommendationService`. Den skal oppdatere hvis regelen finnes fra før, og opprette regelen ellers. Dette kan du unit teste med enkel mocking. 
   1. Hovedlogikken i hele applikasjonen er i metoden `GetClothingRecommendation()` i `ClothingRecommendationService`. Det finnes allerede en unit test av denne, ferdig med mocking. Denne tester et "happy case", dvs. at alt går bra. Bruk unit testing til å finne feil og problemer i koden. Prøv å finne ut hvilke "grensetilfeller" som finnes, dvs. at alt ikke er som det skal. Noen ideer er under, men prøv å tenke selv, hva som kan være "særtilfeller" i alle inputene:
        - en ugyldig posisjon
        - en posisjon veldig langt unna
        - et tidspunkt det ikke finnes værmelding for
        - hva om ingen regler matcher gitt temperatur
1. Det er mye funksjonalitet som mangler. Ta tak i noe du ser behovet for og som du tror du kan få til. Under er noen ideer, men tenk gjerne ut noe selv!
    - Ta hensyn til regn. (Det er delvis lagt opp til dette.) Hvordan får man det fra Yr? Hvordan må koden endres for å matche opp reglene også ut fra regn? 
    - La brukeren velge sted istedenfor bare å gi anbefaling ut fra hvor han eller hun er nå:
      
      Enten la brukeren velge først region, så by, og så sted - for eksempel i drop downs (`<select>`). Eller ha et tekstfelt hvor man skriver inn og får et søkeresultat. Et lite tips: Om man har en `oninput` på tekstfeltet i HTML, og så tegner opp hver gang teksten endres, så kan det være lurt, for brukeropplevelsen, å sette fokus ([www.w3schools.com/jsref/met_html_focus.asp](https://www.w3schools.com/jsref/met_html_focus.asp)) til tekstfeltet etter at det er tegnet opp på nytt - slik at man kan fortsette å skrive flere bokstaver i stedsnavnet uten å måtte klikke i feltet på nytt. 

      Her må du utvide servicen, for å la frontend laste ned listen over steder. 
        
    - Utvid klesanbefalingen fra å være kun tekst til å ha en egen klasse `Clothing`. Kanskje er det egne felt for hva du skal ha på hodet, overkropp, underkropp, føtter? Hvordan ville noe slik endret frontend, backend og database?
    - Tenk ut noe selv, begynn gjerne med noe veldig lite. Legg listen lavt. Det er bedre å gjøre mange små endringer du får til - enn en stor endring som du ikke får til. 
    - Om det er riktig for _deg_, skriv om brukergrensesnittet til f.eks. Vue eller et annet SPA-rammeverk. 
    - Lag en WPF eller Xamarin.Forms frontend til samme applikasjon. 
    - Lag en veldig enkel innlogging med kun brukernavn (ikke passord). La hver bruker ha sine egne regler. Databasen er lagt opp til det allerede. Tanken er at regler hvor `user` er `null` er default regler, og at når man oppretter en ny bruker, så kopieres default reglene til denne brukeren, som så kan endre, slette og legge til nye egne regler. 
    - Alternativt, integrer med auth0.com for ekte innlogging. Men husk at en slik oppgave, i mindre grad enn de andre, trener opp grunleggende ferdigheter - og mer blir spesifikk "teknikk" for å få til akkurat dette. 
    - Det er også mulig å sette opp hosting av applikasjonen på Azure. Det skal være free trial i 30 dager - det _kan_ være god og viktig læring om du vil i devops-retning. Men her gjelder det samme som for forrige punkt; husk at en slik oppgave, i mindre grad enn de andre, trener opp grunleggende ferdigheter - og mer blir spesifikk "teknikk" for å få til akkurat dette. 