# Définissez les dossiers à nettoyer
$TempFolders = "$env:temp", "$env:windir\temp"
$DownloadsFolder = "$env:userprofile\downloads"

# Définissez le nombre de jours au-delà duquel les fichiers seront supprimés
$DaysToKeepFiles = 7

# Obtenez la date actuelle
$CurrentDate = Get-Date

# Supprimez les fichiers temporaires
foreach ($TempFolder in $TempFolders)
{
    Get-ChildItem $TempFolder -Recurse | Where-Object {
        !$_.PSIsContainer -and $_.LastWriteTime -lt $CurrentDate.AddDays(-$DaysToKeepFiles)
    } | Remove-Item -Force
}

# Supprimez les fichiers du dossier Téléchargements
Get-ChildItem $DownloadsFolder -Recurse | Where-Object {
    !$_.PSIsContainer -and $_.LastWriteTime -lt $CurrentDate.AddDays(-$DaysToKeepFiles)
} | Remove-Item -Force

# Affichez un message de confirmation
Write-Host "Nettoyage de disque terminé !"
