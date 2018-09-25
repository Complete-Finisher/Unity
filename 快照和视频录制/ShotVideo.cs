using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//一个视频的组成可以看成 每秒24 帧的连续图像组成。
//后期将调用ffmpeg的库将图片拼接成视频

/*
##名称：ffmpeg实现将图片转换为视频
##平台：ubuntu(已经安装好了ffmpeg工具)
##日期：2017年12月10日
简介：
      因为学习需要，需要将连续图片转换成视频，昨天和今天早上用opencv实现了，
      但是对于视频的处理用ffmpeg工具，更为强大。

1.基本格式

终端输入： ffmpeg -f image2 -i /home/ttwang/images/image%d.jpg tt.mp4

其中/home/ttwang/images/images%d.jpg 为图片路径
图片的命名格式为image%d.jpg形式，即：image0 image1 image2 .......
tt.mp4为输出视频文件名

2.指定编码格式的使用

终端输入： ffmpeg -f image2 -i /home/ttwang/images/image%d.jpg  -vcodec libx264  tt.mp4

3.指定输出帧率

终端输入：ffmpeg -f image2 -i /home/ttwang/images/image%d.jpg  -vcodec libx264 -r 10  tt.mp4

-r 10 表示定义帧率为10，这样输出的视频就是每秒播放十帧

4.其余ffmpeg小技巧参考资料
   参考资料

*/




public class ShotVideo : MonoBehaviour
{
    public float ScreenShotHeight = 500;
    public float ScreenShotWith = 500;
    public string PicSavePath = "MyPhoto";


    [SerializeField]
    private Texture2D picture;
    private RenderTexture renderBuffer;
    private string Path = "";
    private bool IsShot = false;
    private static int count = 0;


    public string RecordPath = "";
    private bool IsRecord = false;
    private static int RecordCount = 0;

    // Use this for initialization
    void Start()
    {
        picture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGBA32, false, true);
        Path = Application.dataPath + "/" + PicSavePath;
       
        //Debug.LogError(Path);
        SetPath(Path);
        SetPath(RecordPath);

    }

    public void SetPath(string _s)
    {
        //path
        if (Directory.Exists(_s))
        {
            FileAttributes attr = File.GetAttributes(_s);
            if (attr == FileAttributes.Directory)
                Directory.Delete(_s, true);
            else
                File.Delete(_s);
        }
        if (!Directory.Exists(_s))
            Directory.CreateDirectory(_s);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsShot)
            ShotScreen();
        if (Input.GetKeyDown(KeyCode.R))
            Record();
        if (Input.GetKeyDown(KeyCode.S))
            StopRecord();

    }

    public bool StartRecord()
    {
        IsRecord = true;
        return IsRecord;
    }
    public bool StopRecord()
    {
        IsRecord = false;
        return IsRecord;
    }

    public void Record()
    {
        StartRecord();
        StartCoroutine(CaptureVideo());
    }

    public void ShotScreen()
    {
        IsShot = true;
        StartCoroutine(CaptureScreen());
    }


    public IEnumerator CaptureScreen()
    {
        yield return new WaitForEndOfFrame();
        picture.ReadPixels(
            new Rect(0, 0, Screen.width, Screen.height), 0, 0
            );

        picture.Apply();
        var bytes = picture.EncodeToPNG();
        File.WriteAllBytes(Path + "/" + count.ToString() + ".png", bytes);
        count++;
        Debug.Log("Fin the work gender texture");

        yield return new WaitForSeconds(0.1f);
        IsShot = false;
    }

    public IEnumerator CaptureVideo()
    {
        while (IsRecord)
        {
            picture.ReadPixels(
          new Rect(0, 0, Screen.width, Screen.height), 0, 0
          );

            picture.Apply();
            var bytes = picture.EncodeToPNG();
            File.WriteAllBytes(RecordPath + "/" + RecordCount.ToString() + ".png", bytes);
            RecordCount++;
            Debug.Log("Fin the work CaptureVideo texture " + RecordCount);
            yield return new WaitForEndOfFrame();
        }

    }

}