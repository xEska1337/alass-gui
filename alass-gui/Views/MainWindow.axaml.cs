using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Net.Http;
using System.IO.Compression;
using System.Threading.Tasks;
using Avalonia.Threading;

namespace alass_gui.Views
{
    public partial class MainWindow : Window
    {
        private static readonly HttpClient Client = new();

        private string[] Languages { get; } =
        [
            "", "aar", "abk", "ace", "ach", "ada", "ady", "afa", "afh", "afr", "ain", "aka", "akk", "alb", "sqi", "ale",
            "alg", "alt", "amh", "ang", "anp", "apa", "ara", "arc", "arg", "arm", "hye", "arn", "arp", "art", "arw",
            "asm", "ast", "ath", "aus", "ava", "ave", "awa", "aym", "aze", "bad", "bai", "bak", "bal", "bam", "ban",
            "baq", "eus", "bas", "bat", "bej", "bel", "bem", "ben", "ber", "bho", "bih", "bik", "bin", "bis", "bla",
            "bnt", "tib", "bod", "bos", "bra", "bre", "btk", "bua", "bug", "bul", "bur", "mya", "byn", "cad", "cai",
            "car", "cat", "cau", "ceb", "cel", "cze", "ces", "cha", "chb", "che", "chg", "chi", "zho", "chk", "chm",
            "chn", "cho", "chp", "chr", "chu", "chv", "chy", "cmc", "cnr", "cop", "cor", "cos", "cpe", "cpf", "cpp",
            "cre", "crh", "crp", "csb", "cus", "wel", "cym", "cze", "ces", "dak", "dan", "dar", "day", "del", "den",
            "ger", "deu", "dgr", "din", "div", "doi", "dra", "dsb", "dua", "dum", "dut", "nld", "dyu", "dzo", "efi",
            "egy", "eka", "gre", "ell", "elx", "eng", "enm", "epo", "est", "baq", "eus", "ewe", "ewo", "fan", "fao",
            "per", "fas", "fat", "fij", "fil", "fin", "fiu", "fon", "fre", "fra", "fre", "fra", "frm", "fro", "frr",
            "frs", "fry", "ful", "fur", "gaa", "gay", "gba", "gem", "geo", "kat", "ger", "deu", "gez", "gil", "gla",
            "gle", "glg", "glv", "gmh", "goh", "gon", "gor", "got", "grb", "grc", "gre", "ell", "grn", "gsw", "guj",
            "gwi", "hai", "hat", "hau", "haw", "heb", "her", "hil", "him", "hin", "hit", "hmn", "hmo", "hrv", "hsb",
            "hun", "hup", "arm", "hye", "iba", "ibo", "ice", "isl", "ido", "iii", "ijo", "iku", "ile", "ilo", "ina",
            "inc", "ind", "ine", "inh", "ipk", "ira", "iro", "ice", "isl", "ita", "jav", "jbo", "jpn", "jpr", "jrb",
            "kaa", "kab", "kac", "kal", "kam", "kan", "kar", "kas", "geo", "kat", "kau", "kaw", "kaz", "kbd", "kha",
            "khi", "khm", "kho", "kik", "kin", "kir", "kmb", "kok", "kom", "kon", "kor", "kos", "kpe", "krc", "krl",
            "kro", "kru", "kua", "kum", "kur", "kut", "lad", "lah", "lam", "lao", "lat", "lav", "lez", "lim", "lin",
            "lit", "lol", "loz", "ltz", "lua", "lub", "lug", "lui", "lun", "luo", "lus", "mac", "mkd", "mad", "mag",
            "mah", "mai", "mak", "mal", "man", "mao", "mri", "map", "mar", "mas", "may", "msa", "mdf", "mdr", "men",
            "mga", "mic", "min", "mis", "mac", "mkd", "mkh", "mlg", "mlt", "mnc", "mni", "mno", "moh", "mon", "mos",
            "mao", "mri", "may", "msa", "mul", "mun", "mus", "mwl", "mwr", "bur", "mya", "myn", "myv", "nah", "nai",
            "nap", "nau", "nav", "nbl", "nde", "ndo", "nds", "nep", "new", "nia", "nic", "niu", "dut", "nld", "nno",
            "nob", "nog", "non", "nor", "nqo", "nso", "nub", "nwc", "nya", "nym", "nyn", "nyo", "nzi", "oci", "oji",
            "ori", "orm", "osa", "oss", "ota", "oto", "paa", "pag", "pal", "pam", "pan", "pap", "pau", "peo", "per",
            "fas", "phi", "phn", "pli", "pol", "pon", "por", "pra", "pro", "pus", "qaa-qtz", "que", "raj", "rap", "rar",
            "roa", "roh", "rom", "rum", "ron", "rum", "ron", "run", "rup", "rus", "sad", "sag", "sah", "sai", "sal",
            "sam", "san", "sas", "sat", "scn", "sco", "sel", "sem", "sga", "sgn", "shn", "sid", "sin", "sio", "sit",
            "sla", "slo", "slk", "slo", "slk", "slv", "sma", "sme", "smi", "smj", "smn", "smo", "sms", "sna", "snd",
            "snk", "sog", "som", "son", "sot", "spa", "alb", "sqi", "srd", "srn", "srp", "srr", "ssa", "ssw", "suk",
            "sun", "sus", "sux", "swa", "swe", "syc", "syr", "tah", "tai", "tam", "tat", "tel", "tem", "ter", "tet",
            "tgk", "tgl", "tha", "tib", "bod", "tig", "tir", "tiv", "tkl", "tlh", "tli", "tmh", "tog", "ton", "tpi",
            "tsi", "tsn", "tso", "tuk", "tum", "tup", "tur", "tut", "tvl", "twi", "tyv", "udm", "uga", "uig", "ukr",
            "umb", "und", "urd", "uzb", "vai", "ven", "vie", "vol", "vot", "wak", "wal", "war", "was", "wel", "cym",
            "wen", "wln", "wol", "xal", "xho", "yao", "yap", "yid", "yor", "ypk", "zap", "zbl", "zen", "zgh", "zha",
            "chi", "zho", "znd", "zul", "zun", "zxx", "zza"
        ];

        private string _folderPath = "";
        private string _selectedVideoFile = "";
        private string _selectedReferenceSubs = "";
        private string _selectedSubsToSync = "";
        private string _alassPath = "";
        private string _subOutput = "";
        private readonly string _settingsFilePath = Path.Combine(AppContext.BaseDirectory, "settings.json");
        private AppSettings _currentSettings = new AppSettings();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LangugeCode.ItemsSource = Languages.OrderBy(lang => lang).ToList();
            this.Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
        }

        private async void MainWindow_Loaded(object? sender, RoutedEventArgs e)
        {
            try
            {
                LoadSettings();
                NegativeTimestampCheck.IsChecked = _currentSettings.NagativeTimestampSetting;
                DisableFpsGuessCheck.IsChecked = _currentSettings.FpsGuessingSetting;
                NoSplitingCheck.IsChecked = _currentSettings.NoSplitingSetting;
                SpeedOptimizationCheck.IsChecked = _currentSettings.SpeedOptSetting;
                SplitPenalty.Value = _currentSettings.SplitPenalitSetting;
                Interval.Value = _currentSettings.IntervalSetting;
                SubsNameLikeVideoCheck.IsChecked = _currentSettings.SubsLikeVideoSetting;
                ReplaceSubsCheck.IsChecked = _currentSettings.ReplaceSubsSetting;
                LangugeCode.SelectedIndex = _currentSettings.SelectedLanguageCodeSetting;

                if (_currentSettings.Px != 0 || _currentSettings.Py != 0)
                {
                    this.Position = new Avalonia.PixelPoint(_currentSettings.Px, _currentSettings.Py);
                }

                var exeDirectory = AppContext.BaseDirectory;
                var isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

                if (isLinux)
                {
                    _alassPath = Path.Combine(exeDirectory, "alass-linux64");
                    if (!File.Exists(_alassPath))
                    {
                        await DownloadAlassAsync(true, exeDirectory, _alassPath);
                    }
                }
                else
                {
                    _alassPath = Path.Combine(exeDirectory, "alass-windows64");
                    if (!Directory.Exists(_alassPath))
                    {
                        await DownloadAlassAsync(false, exeDirectory, _alassPath);
                    }
                }
            }
            catch (Exception ex)
            {
                var errorBox = MessageBoxManager.GetMessageBoxStandard(
                    "Startup Error",
                    $"An error occurred during startup: {ex.Message}",
                    ButtonEnum.Ok,
                    MsBox.Avalonia.Enums.Icon.Error);
                await errorBox.ShowWindowDialogAsync(this);
            }
        }

        private async Task DownloadAlassAsync(bool isLinux, string exeDirectory, string targetPath)
        {
            DownloadOverlay.IsVisible = true;
            DownloadProgressBar.Value = 0;
            DownloadStatusText.Text = isLinux ? "Downloading ALASS (Linux)..." : "Downloading ALASS (Windows)...";

            try
            {
                var url = isLinux
                    ? "https://github.com/kaegi/alass/releases/download/v2.0.0/alass-linux64"
                    : "https://github.com/kaegi/alass/releases/download/v2.0.0/alass-windows64.zip";

                var downloadPath = isLinux ? targetPath : Path.Combine(exeDirectory, "alass-windows64.zip");
                
                using var response = await Client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                var totalBytes = response.Content.Headers.ContentLength;
                await using var contentStream = await response.Content.ReadAsStreamAsync();
                await using var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write, FileShare.None,
                    8192, true);
                
                var buffer = new byte[8192];
                long totalRead = 0;
                int bytesRead;

                while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    await fileStream.WriteAsync(buffer, 0, bytesRead);
                    totalRead += bytesRead;

                    if (!totalBytes.HasValue) continue;
                    var percentage = ((double)totalRead / totalBytes.Value) * 100;
                    DownloadProgressBar.Value = percentage;
                }
                
                fileStream.Close();
                
                if (isLinux)
                {
                    DownloadStatusText.Text = "Applying permissions...";
                    await Process.Start(new ProcessStartInfo
                    {
                        FileName = "chmod",
                        Arguments = $"+x \"{targetPath}\"",
                        UseShellExecute = false
                    })?.WaitForExitAsync()!;
                }
                else
                {
                    DownloadStatusText.Text = "Extracting files...";
                    await ZipFile.ExtractToDirectoryAsync(downloadPath, exeDirectory, overwriteFiles: true);
                    File.Delete(downloadPath);
                }
                
                DownloadOverlay.IsVisible = false;
                var successBox = MessageBoxManager.GetMessageBoxStandard(
                    "Download Complete",
                    "ALASS has been successfully downloaded and installed.",
                    ButtonEnum.Ok,
                    MsBox.Avalonia.Enums.Icon.Success);
                await successBox.ShowWindowDialogAsync(this);
            }
            catch (Exception ex)
            {
                DownloadOverlay.IsVisible = false;
                var errorBox = MessageBoxManager.GetMessageBoxStandard(
                    "Download Failed",
                    $"Failed to download ALASS automatically: {ex.Message}\nPlease download it manually.",
                    ButtonEnum.Ok,
                    MsBox.Avalonia.Enums.Icon.Error);
                await errorBox.ShowWindowDialogAsync(this);
            }
        }

        private async void browseFolderDialog_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                var topLevel = TopLevel.GetTopLevel(this);
                if (topLevel == null) return;

                var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
                {
                    Title = "Select Folder",
                    AllowMultiple = false
                });

                if (folders.Count > 0)
                {
                    MainPath.Text = folders[0].Path.LocalPath;
                }
            }
            catch (Exception ex)
            {
                await MessageBoxManager.GetMessageBoxStandard("Error", $"Could not open folder picker: {ex.Message}",
                    ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error).ShowWindowDialogAsync(this);
            }
        }

        private void scanFolder_Click(object? sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(MainPath.Text) && Directory.Exists(MainPath.Text))
            {
                _folderPath = MainPath.Text;

                var videoFiles = Directory.EnumerateFiles(_folderPath, "*.*")
                    .Where(s => s.EndsWith(".mkv", StringComparison.OrdinalIgnoreCase) ||
                                s.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase) ||
                                s.EndsWith(".avi", StringComparison.OrdinalIgnoreCase) ||
                                s.EndsWith(".mov", StringComparison.OrdinalIgnoreCase) ||
                                s.EndsWith(".ts", StringComparison.OrdinalIgnoreCase) ||
                                s.EndsWith(".m4v", StringComparison.OrdinalIgnoreCase))
                    .Select(Path.GetFileName).ToList();

                var subFiles = Directory.EnumerateFiles(_folderPath, "*.*")
                    .Where(s => s.EndsWith(".srt", StringComparison.OrdinalIgnoreCase) ||
                                s.EndsWith(".ssa", StringComparison.OrdinalIgnoreCase) ||
                                s.EndsWith(".ass", StringComparison.OrdinalIgnoreCase) ||
                                s.EndsWith(".idx", StringComparison.OrdinalIgnoreCase))
                    .Select(Path.GetFileName).ToList();

                VideoFileList.ItemsSource = videoFiles;
                ReferenceSubsList.ItemsSource = subFiles;
                SubsToSyncList.ItemsSource = subFiles;
            }
            else
            {
                MessageBoxManager.GetMessageBoxStandard("Error", "Select correct folder path", ButtonEnum.Ok,
                    MsBox.Avalonia.Enums.Icon.Error).ShowWindowDialogAsync(this);
            }
        }

        private void videoFileList_SelectionChangeCommitted(object? sender, SelectionChangedEventArgs e)
        {
            if (VideoFileList.SelectedItem is string selectedFileName)
            {
                _selectedVideoFile = "\"" + Path.Combine(_folderPath, selectedFileName) + "\"";
            }
        }

        private void referenceSubsList_SelectionChangeCommitted(object? sender, SelectionChangedEventArgs e)
        {
            if (ReferenceSubsList.SelectedItem is string selectedFileName)
            {
                _selectedReferenceSubs = "\"" + Path.Combine(_folderPath, selectedFileName) + "\"";
            }
        }

        private void subsToSyncList_SelectionChangeCommitted(object? sender, SelectionChangedEventArgs e)
        {
            if (SubsToSyncList.SelectedItem is string selectedFileName)
            {
                _selectedSubsToSync = "\"" + Path.Combine(_folderPath, selectedFileName) + "\"";
            }
        }

        private void SubOutName()
        {
            var languageCodeSelected = "";
            if (LangugeCode.SelectedItem is string lang && !string.IsNullOrEmpty(lang))
            {
                languageCodeSelected = "." + lang;
            }

            var subsToSyncStr = SubsToSyncList.SelectedItem as string ?? "";
            var videoFileStr = VideoFileList.SelectedItem as string ?? "";

            switch (SubsNameLikeVideoCheck.IsChecked)
            {
                case true when ReplaceSubsCheck.IsChecked != true && VideoFileList.SelectedIndex != -1:
                {
                    var fileName = Path.GetFileNameWithoutExtension(videoFileStr);
                    var fileExtension = Path.GetExtension(subsToSyncStr);
                    var fileNewName = fileName + "_synced" + languageCodeSelected + fileExtension;
                    _subOutput = "\"" + Path.Combine(_folderPath, fileNewName) + "\"";
                    break;
                }
                case true when ReplaceSubsCheck.IsChecked == true && VideoFileList.SelectedIndex != -1:
                {
                    var fileName = Path.GetFileNameWithoutExtension(videoFileStr);
                    var fileExtension = Path.GetExtension(subsToSyncStr);
                    var fileNewName = fileName + languageCodeSelected + fileExtension;
                    _subOutput = "\"" + Path.Combine(_folderPath, fileNewName) + "\"";
                    break;
                }
                default:
                {
                    if (ReplaceSubsCheck.IsChecked == true)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(subsToSyncStr);
                        var fileExtension = Path.GetExtension(subsToSyncStr);
                        var fileNewName = fileName + languageCodeSelected + fileExtension;
                        _subOutput = "\"" + Path.Combine(_folderPath, fileNewName) + "\"";
                    }
                    else
                    {
                        var fileName = Path.GetFileNameWithoutExtension(subsToSyncStr);
                        var fileExtension = Path.GetExtension(subsToSyncStr);
                        var fileNewName = fileName + "_synced" + languageCodeSelected + fileExtension;
                        _subOutput = "\"" + Path.Combine(_folderPath, fileNewName) + "\"";
                    }

                    break;
                }
            }
        }

        private async void syncButton_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                if (!((ReferenceSubsList.SelectedIndex == -1 && VideoFileList.SelectedIndex != -1 &&
                       SubsToSyncList.SelectedIndex != -1) ||
                      (ReferenceSubsList.SelectedIndex != -1 && SubsToSyncList.SelectedIndex != -1)))
                {
                    await MessageBoxManager.GetMessageBoxStandard(
                        "Error",
                        "Select at least video and subtitle to sync",
                        ButtonEnum.Ok,
                        MsBox.Avalonia.Enums.Icon.Error).ShowWindowDialogAsync(this);
                    return;
                }

                var isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
                var executableFile = isLinux ? _alassPath : Path.Combine(_alassPath, "alass.bat");

                var splitPenaltyValue = ((int)(SplitPenalty.Value ?? 7)).ToString();
                var intervalValue = ((int)(Interval.Value ?? 1)).ToString();

                SubOutName();
                var targetInput = ReferenceSubsList.SelectedIndex == -1 ? _selectedVideoFile : _selectedReferenceSubs;

                ConsoleOutput.Text = "Starting ALASS...\n";

                var workingDir = MainPath.Text;
                if (string.IsNullOrWhiteSpace(workingDir) || !Directory.Exists(workingDir))
                {
                    await MessageBoxManager.GetMessageBoxStandard(
                        "Error",
                        "The selected directory does not exist or is invalid.",
                        ButtonEnum.Ok,
                        MsBox.Avalonia.Enums.Icon.Error).ShowWindowDialogAsync(this);
                    return;
                }

                var psi = new ProcessStartInfo
                {
                    FileName = executableFile,
                    WorkingDirectory = workingDir,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                psi.ArgumentList.Add(targetInput.Trim('"'));
                psi.ArgumentList.Add(_selectedSubsToSync.Trim('"'));
                psi.ArgumentList.Add(_subOutput.Trim('"'));

                psi.ArgumentList.Add("--split-penalty");
                psi.ArgumentList.Add(splitPenaltyValue);
                psi.ArgumentList.Add("--interval");
                psi.ArgumentList.Add(intervalValue);

                if (NegativeTimestampCheck.IsChecked == true) psi.ArgumentList.Add("--allow-negative-timestamps");
                if (DisableFpsGuessCheck.IsChecked == true) psi.ArgumentList.Add("--disable-fps-guessing");
                if (NoSplitingCheck.IsChecked == true) psi.ArgumentList.Add("--no-split");
                if (SpeedOptimizationCheck.IsChecked == true) psi.ArgumentList.Add("--speed-optimization");

                var process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                var lastLineWasProgress = false;

                process.OutputDataReceived += (_, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                    {
                        Dispatcher.UIThread.Post(() =>
                        {
                            var isProgress = ev.Data.Contains($"[") && ev.Data.Contains($"]") && ev.Data.Contains($"%");

                            if (isProgress && lastLineWasProgress)
                            {
                                var lastNewline = ConsoleOutput.Text.LastIndexOf('\n',
                                    Math.Max(0, ConsoleOutput.Text.Length - 2));
                                if (lastNewline >= 0)
                                {
                                    ConsoleOutput.Text = string.Concat(ConsoleOutput.Text.AsSpan(0, lastNewline + 1), ev.Data, "\n");
                                }
                                else
                                {
                                    ConsoleOutput.Text = ev.Data + "\n";
                                }
                            }
                            else
                            {
                                ConsoleOutput.Text += ev.Data + "\n";
                            }

                            lastLineWasProgress = isProgress;
                            ConsoleOutput.CaretIndex = ConsoleOutput.Text.Length;
                        });
                    }
                };

                process.ErrorDataReceived += (_, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                    {
                        Dispatcher.UIThread.Post(() =>
                        {
                            ConsoleOutput.Text += "[ERROR] " + ev.Data + "\n";
                            ConsoleOutput.CaretIndex = ConsoleOutput.Text.Length;
                        });
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
            }
            catch (Exception ex)
            {
                ConsoleOutput.Text += $"\n[CRITICAL ERROR] {ex.Message}\n";

                await MessageBoxManager.GetMessageBoxStandard(
                    "Sync Error",
                    $"An error occurred while running ALASS: {ex.Message}",
                    ButtonEnum.Ok,
                    MsBox.Avalonia.Enums.Icon.Error).ShowWindowDialogAsync(this);
            }
        }

        private void MainWindow_Closing(object? sender, WindowClosingEventArgs e)
        {
            _currentSettings.NagativeTimestampSetting = NegativeTimestampCheck.IsChecked ?? false;
            _currentSettings.FpsGuessingSetting = DisableFpsGuessCheck.IsChecked ?? false;
            _currentSettings.NoSplitingSetting = NoSplitingCheck.IsChecked ?? false;
            _currentSettings.SpeedOptSetting = SpeedOptimizationCheck.IsChecked ?? false;
            _currentSettings.SplitPenalitSetting = SplitPenalty.Value ?? 7;
            _currentSettings.IntervalSetting = Interval.Value ?? 1;
            _currentSettings.Px = this.Position.X;
            _currentSettings.Py = this.Position.Y;
            _currentSettings.SubsLikeVideoSetting = SubsNameLikeVideoCheck.IsChecked ?? false;
            _currentSettings.ReplaceSubsSetting = ReplaceSubsCheck.IsChecked ?? false;
            _currentSettings.SelectedLanguageCodeSetting = LangugeCode.SelectedIndex;
            SaveSettings();
        }

        private void alassGitHubOpen_Click(object? sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/kaegi/alass") { UseShellExecute = true });
        }

        private void myGithub_Click_1(object? sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/xEska1337") { UseShellExecute = true });
        }

        private void LoadSettings()
        {
            if (!File.Exists(_settingsFilePath)) return;
            try
            {
                var json = File.ReadAllText(_settingsFilePath);
                _currentSettings = JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
            }
            catch
            {
                _currentSettings = new AppSettings();
            }
        }

        private void SaveSettings()
        {
            try
            {
                var json = JsonSerializer.Serialize(_currentSettings,
                    new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_settingsFilePath, json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to save settings: {ex.Message}");
            }
        }
    }

    public class AppSettings
    {
        public bool NagativeTimestampSetting { get; set; }
        public bool FpsGuessingSetting { get; set; }
        public bool NoSplitingSetting { get; set; }
        public bool SpeedOptSetting { get; set; }
        public decimal SplitPenalitSetting { get; set; } = 7;
        public decimal IntervalSetting { get; set; } = 1;
        public int Px { get; set; }
        public int Py { get; set; }
        public bool SubsLikeVideoSetting { get; set; }
        public bool ReplaceSubsSetting { get; set; }
        public int SelectedLanguageCodeSetting { get; set; }
    }
}