using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Reward.China
{
    public class HeadInfo : IHeadInfo
    {
        IHttp http;
        IRemoteImageLoader loader;
        public string nick { get; set; }
        public string headUrl { get; set; }
        Sprite sprite;
        bool isInited;
        async void tryInit()
        {
            if (string.IsNullOrEmpty(headUrl))
            {
                isInited = false;
                sprite = null;
                return;
            }
            if (isInited) return;
            isInited = true;
            sprite = await loader.LoadImageAsync(headUrl);
        }
        //async void loadHead()
        //{
        //    if (string.IsNullOrEmpty(headUrl)) return;
        //    var data = await http.GetBytes(headUrl);
        //    sprite = convertSprite(data);
        //}
        //Sprite convertSprite(byte[] data)
        //{
        //    Texture2D texture = new Texture2D(512, 512, UnityEngine.Experimental.Rendering.DefaultFormat.LDR, UnityEngine.Experimental.Rendering.TextureCreationFlags.None);
        //    texture.LoadImage(data);
        //    Sprite sprite = Sprite.Create(texture, new Rect() { x = 0, y = 0, width = texture.width, height = texture.height }, new Vector2(0.5f, 0.5f));
        //    return sprite;
        //}
        public bool tryGetHeadImg(out Sprite sprite)
        {
            tryInit();
            sprite = default;
            if (this.sprite == null)
                return false;
            sprite = this.sprite;
            return true;
        }
    }
}

