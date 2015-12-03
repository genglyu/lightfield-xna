using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Prototype_lightfieldDiplaysystemNo2.ConfigTools;
using Prototype_lightfieldDiplaysystemNo2.MainViewSystem.Modelmanager;

namespace Prototype_lightfieldDiplaysystemNo2.MainViewSystem
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Prototype_LightfieldDisplaySystemII : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ConfigData_of_XML configData;

        Modelmanager.Modelmanager modelManager;

        public Camera.Camera currentCamera;

        public List<List<RenderTarget2D>> renderToTextureList;
        public List<List<Camera.Camera>> cameraList;
        public List<Vector2> mecroholePositionList;

        public Texture2D textureWhite;
     
        int currentViewportOffsetX = 0;
        int currentViewportOffsetY = 0;

        public Prototype_LightfieldDisplaySystemII()
        {
            graphics = new GraphicsDeviceManager(this);
            configData = new ConfigData_of_XML();
            configData.LoadFromFile("ConfigFile");
            
            Content.RootDirectory = "Content";

            
            //===有关显示区域大小的设定似乎必须在构造函数中进行==========================================
            graphics.PreferredBackBufferWidth = configData.screenOneWidth_pixel + configData.screenTwoWidth_pixel;
            graphics.PreferredBackBufferHeight = configData.displayzone_top_pixel + configData.displayzone_height_pixel + configData.subViewportHeight;

           
        }
        
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            configData.LoadFromFile("ConfigFile");

            graphics.SynchronizeWithVerticalRetrace = true;

            IsMouseVisible = true;

            //====无边框窗口==========================================
            System.Windows.Forms.Form MyGameForm = (System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(this.Window.Handle);
            MyGameForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MyGameForm.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            MyGameForm.Location = new System.Drawing.Point(0, 0);
            //========================================================

            
            //==========================================================================================
            renderToTextureList = new List<List<RenderTarget2D>>(configData.subViewportWidth);


            //==========================================================================================
            cameraList = new List<List<Camera.Camera>>();
            for (int i = 0; i < configData.subViewportWidth; i++)
            {
                List<RenderTarget2D> renderToTextureListVertical = new List<RenderTarget2D>();
                List<Camera.Camera> cameraListVertical = new List<Camera.Camera>();
                for (int j = 0; j < configData.subViewportHeight; j++)
                {
                    renderToTextureListVertical.Add(
                        new RenderTarget2D(GraphicsDevice,
                            configData.displayzone_width_pixel,
                            configData.displayzone_height_pixel,
                            false, GraphicsDevice.DisplayMode.Format,
                            DepthFormat.Depth24));

                    cameraListVertical.Add(
                        new Camera.Camera(this,
                            new Vector3(0, 0, 0),
                            -Vector3.UnitZ,
                            Vector3.Up,
                            i,
                            j,
                            configData.screenOneWidth / configData.screenOneWidth_pixel,
                            configData.screenOneHeight / configData.screenOneHeight_pixel,
                            configData.widthBetweenScreens,
                            configData.subViewportWidth,
                            configData.subViewportHeight,
                            configData.displayzone_width_pixel,
                            configData.displayzone_height_pixel));
                }
                renderToTextureList.Add(renderToTextureListVertical);
                cameraList.Add(cameraListVertical);
            }
            //=====================================================================================
            mecroholePositionList = new List<Vector2>();

            if (configData.isScreensEqual_to_EachOther == true)
            {
                for (int viewportCountHorizontal = 0; viewportCountHorizontal < (configData.displayzone_width_pixel / configData.subViewportWidth); viewportCountHorizontal++)
                {
                    for (int viewportCountVertical = 0; viewportCountVertical < (configData.displayzone_height_pixel / configData.subViewportHeight); viewportCountVertical++)
                    {
                        mecroholePositionList.Add(
                            new Vector2(
                                configData.screenOneWidth_pixel
                                     + configData.displayzone_left_pixel
                                     - configData.screenOffsetX * (float)configData.screenTwoWidth_pixel / configData.screenTwoWidth
                                     + ((float)viewportCountHorizontal + 0.5f) * configData.subViewportWidth
                                     - ((float)configData.mecroholeWidth / 2),
                                0
                                     + configData.displayzone_top_pixel
                                     - configData.screenOffsetY * (float)configData.screenTwoHeight_pixel / configData.screenTwoHeight
                                     + ((float)viewportCountVertical + 0.5f) * configData.subViewportWidth
                                     - ((float)configData.mecroholeHeight / 2)
                                ));
                    }
                }
            }
            else
            {
                for (int viewportCountHorizontal = 0; viewportCountHorizontal < (configData.displayzone_width_pixel / configData.subViewportWidth); viewportCountHorizontal++)
                {
                    for (int viewportCountVertical = 0; viewportCountVertical < (configData.displayzone_height_pixel / configData.subViewportHeight); viewportCountVertical++)
                    {
                        //===========需要修正，未完成===========================================================
                        mecroholePositionList.Add(
                            new Vector2(
                                configData.screenOneWidth_pixel
                                     + configData.displayzone_left_pixel
                                     - configData.screenOffsetX * (float)configData.screenTwoWidth_pixel / configData.screenTwoWidth
                                     + ((float)viewportCountHorizontal + 0.5f) * configData.subViewportWidth
                                     - ((float)configData.mecroholeWidth / 2),
                                0
                                     + configData.displayzone_top_pixel
                                     - configData.screenOffsetY * (float)configData.screenTwoHeight_pixel / configData.screenTwoHeight
                                     + ((float)viewportCountVertical + 0.5f) * configData.subViewportWidth
                                     - ((float)configData.mecroholeHeight / 2)
                                ));
                        //=====================================================================================
                    }
                }
            }
           
            //=====================================================================================
            modelManager = new Modelmanager.Modelmanager(this);
            Components.Add(modelManager);

            //=====================================================================================
            currentCamera = new Camera.Camera(this,
                new Vector3(0, 0, 0),
                Vector3.UnitZ,
                Vector3.Up,
                0,
                0,
                configData.screenOneWidth/configData.screenOneWidth_pixel,
                configData.screenOneHeight/configData.screenOneHeight_pixel,
                configData.widthBetweenScreens,
                configData.subViewportWidth,
                configData.subViewportHeight,
                configData.displayzone_width_pixel,
                configData.displayzone_height_pixel);

            Components.Add(currentCamera);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            textureWhite = Content.Load<Texture2D>(@"texture\white");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (currentViewportOffsetX == 0 && currentViewportOffsetY == 0)
            {
                for (int i = 0; i < configData.subViewportWidth; i++)
                {
                    for (int j = 0; j < configData.subViewportHeight; j++)
                    {
                        GraphicsDevice.SetRenderTarget(renderToTextureList[i][j]);
                        GraphicsDevice.BlendState = BlendState.Opaque;
                        GraphicsDevice.DepthStencilState = DepthStencilState.Default;

                        //GraphicsDevice.Clear(Color.CornflowerBlue);
                        GraphicsDevice.Clear(Color.Black);
                        currentCamera = cameraList[i][j];
                        base.Draw(gameTime);
                    }
                }
            }

            GraphicsDevice.SetRenderTarget(null);       

            GraphicsDevice.Clear(Color.Black);
            //==绘制=========================================================   
            spriteBatch.Begin();
            
            for (int pixelPositionX = 0; pixelPositionX < configData.subViewportWidth; pixelPositionX++)
            {
                for (int pixelPositionY = 0; pixelPositionY < configData.subViewportHeight; pixelPositionY++)
                {
                    for (int viewportCountHorizontal = 0; viewportCountHorizontal < (configData.displayzone_width_pixel / configData.subViewportWidth); viewportCountHorizontal++)
                    {
                        for (int viewportCountVertical = 0; viewportCountVertical < (configData.displayzone_height_pixel / configData.subViewportHeight); viewportCountVertical++)
                        {
                            spriteBatch.Draw(renderToTextureList[pixelPositionX][pixelPositionY],
                                new Rectangle(configData.displayzone_left_pixel + currentViewportOffsetX + pixelPositionX + viewportCountHorizontal * configData.subViewportWidth,
                                    configData.displayzone_top_pixel + currentViewportOffsetY + pixelPositionY + viewportCountVertical * configData.subViewportHeight,
                                    1, 1),
                                new Rectangle(configData.displayzone_left_pixel + currentViewportOffsetX + pixelPositionX + viewportCountHorizontal * configData.subViewportWidth,
                                    configData.displayzone_top_pixel + currentViewportOffsetY + pixelPositionY + viewportCountVertical * configData.subViewportHeight,
                                    1, 1),
                                    /*
                                new Rectangle(currentViewportOffsetX + pixelPositionX + viewportCountHorizontal * configData.subViewportWidth,
                                    currentViewportOffsetY + pixelPositionY + viewportCountVertical * configData.subViewportHeight,
                                    1, 1),*/ 
                                Color.White);
                        }
                    }
                }
            }

            if (configData.isMecroholeEnabled == true)
            {
                float currentOffsetX;
                float currentOffsetY;

                if (configData.isScreensEqual_to_EachOther == true)
                {
                    currentOffsetX = currentViewportOffsetX;
                    currentOffsetY = currentViewportOffsetY;
                }
                else
                {
                    currentOffsetX = currentViewportOffsetX * configData.screenOneWidth / configData.screenOneWidth_pixel
                                       * configData.screenTwoWidth_pixel / configData.screenTwoWidth;
                    currentOffsetY = currentViewportOffsetY * configData.screenOneHeight / configData.screenOneHeight_pixel
                                           * configData.screenTwoHeight_pixel / configData.screenTwoHeight;
                }

                foreach (Vector2 mecroholePosition in mecroholePositionList)
                {
                    spriteBatch.Draw(textureWhite,
                        new Rectangle((int)(mecroholePosition.X + currentOffsetX), (int)(mecroholePosition.Y + currentOffsetY), configData.mecroholeWidth, configData.mecroholeHeight),
                        new Rectangle(0, 0, configData.mecroholeWidth, configData.mecroholeHeight),
                        Color.White);
                }
            }

            spriteBatch.End();
            
            //===============================================================
            if (configData.isScaningEnabled)
            {
                currentViewportOffsetX += configData.mecroholeWidth;
                if (currentViewportOffsetX > configData.subViewportWidth)
                {
                    currentViewportOffsetX = 0;
                    currentViewportOffsetY += configData.mecroholeHeight;
                }
                if (currentViewportOffsetY > configData.subViewportHeight)
                {
                    currentViewportOffsetY = 0;
                }
            }
        }
    }
}
