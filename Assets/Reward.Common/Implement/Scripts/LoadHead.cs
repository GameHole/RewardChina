using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LoadHead : IRemoteImageLoader
{
    IHttp http;
    Sprite convertSprite(byte[] data)
    {
        Texture2D texture = new Texture2D(512, 512, UnityEngine.Experimental.Rendering.DefaultFormat.LDR, UnityEngine.Experimental.Rendering.TextureCreationFlags.None);
        texture.LoadImage(data);
        Sprite sprite = Sprite.Create(texture, new Rect() { x = 0, y = 0, width = texture.width, height = texture.height }, new Vector2(0.5f, 0.5f));
        return sprite;
    }
    public async Task<Sprite> LoadImageAsync(string url)
    {
        if (string.IsNullOrEmpty(url)) return null;
        var data = await http.GetBytes(url);
        return convertSprite(data);
    }
}
