package com.aiqi.cn.whatsthesong.guess.wxapi;

import android.app.Activity;
import android.os.Bundle;
import android.util.Log;

import com.tencent.mm.opensdk.modelbase.BaseReq;
import com.tencent.mm.opensdk.modelbase.BaseResp;
import com.tencent.mm.opensdk.modelmsg.SendAuth;
import com.tencent.mm.opensdk.openapi.IWXAPIEventHandler;
import com.unity.unitywxapi.Wx;

public class WXEntryActivity extends Activity implements IWXAPIEventHandler {
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Log.v("UnityWx","create");
        bind();
    }
    public void bind() {
        try {
            boolean handleIntent = Wx.api.handleIntent(getIntent(), this);
            if (!handleIntent) {
                Log.v("UnityWx", "error");
                finish();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    public void onReq(BaseReq baseReq) {

    }

    @Override
    public void onResp(BaseResp baseResp) {
        SendAuth.Resp resp= (SendAuth.Resp)baseResp;
        int type=resp.getType();
  if(type==1)
            type=0;
        String s = type+ ","
                + baseResp.errCode + ","
                + resp.code;
        if (Wx.msg != null) {
            Log.v("UnityWx",s);
            Wx.msg.onResp(s);
        }
finish();
    }
}
