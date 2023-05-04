using Microsoft.AspNetCore.Mvc;
using Application.Services.DropBox;
using System.IO;
using System.Collections.Generic;
using sharpbox;

namespace EndPoint.Controllers
{
    public class DropBoxController:Controller
    {
        public DropBoxController() { }

        

       /* public IActionResult ChooseFile()
        {
            string tokenFile = "sl.BEzzbROy1I8P17yPrQ5pc1fq3F7nkrRoBIUEb49QsFkYQntmpPT9tNPXgst5sSmpy6ad2EKZrSeEgnKiiqaoWxYta-0ZXmA0ksmDIfChknvi76gANcXNewVUO2bbnlZg9MkQoRY";
            string appKey = "<<appkey>>";
            string appSecret = "<<appsecret>>";
            ICloudStorageAccessToken accessToken;
            CloudStorage storage = new CloudStorage();

            DropBoxConfiguration config =
                CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox) as DropBoxConfiguration;

            if (TryLoadAccessToken(tokenFile, storage, out accessToken))
            {
                storage.Open(config, accessToken);
                var appFolder = storage.GetRoot();

                var folderContent = new List<Tuple<string, bool>>();
                foreach (var entry in appFolder)
                {
                    bool isFolder = entry is ICloudDirectoryEntry;
                    folderContent.Add(new Tuple<string, bool>(entry.Name, isFolder));
                }
                ViewBag.FolderContent = folderContent;
            }
            else
            {
                ICloudStorageAccessToken requestToken;
                if (TryLoadRequestToken(out requestToken))
                {
                    if (requestToken is DropBoxRequestToken)
                    {
                        accessToken =
                            DropBoxStorageProviderTools.ExchangeDropBoxRequestTokenIntoAccessToken(
                                config, appKey, appSecret, (DropBoxRequestToken)requestToken);

                        storage.Open(config, accessToken);

                        using (FileStream fs = System.IO.File.Create(tokenFile))
                        {
                            storage.SerializeSecurityTokenToStream(accessToken, fs); ;
                        }
                    }
                    else
                    {
                        throw new Exception("The request token is not from Dropbox.");
                    }
                }
                else
                {
                    config.AuthorizationCallBack = new Uri("http://localhost:57326/");

                    requestToken = DropBoxStorageProviderTools.GetDropBoxRequestToken(config, appKey, appSecret);

                    Session["dropboxRequestToken"] = requestToken;

                    String url = DropBoxStorageProviderTools.GetDropBoxAuthorizationUrl(
                        config, (DropBoxRequestToken)requestToken);

                    return new RedirectResult(url);
                }
            }

            return View();
        }
        private bool TryLoadRequestToken(out ICloudStorageAccessToken requestToken)
        {
            requestToken = Session["dropboxRequestToken"] as ICloudStorageAccessToken;
            return requestToken != null;
        }

        private bool TryLoadAccessToken(string tokenFile, CloudStorage storage, out ICloudStorageAccessToken accessToken)
        {
            accessToken = null;
            try
            {
                using (FileStream fileStream =
                        System.IO.File.Open(tokenFile, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    accessToken = storage.DeserializeSecurityToken(fileStream);
                }
            }
            catch
            {

            }

            return accessToken != null;
        }*/
    }
}
