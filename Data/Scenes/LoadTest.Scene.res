<root dataType="Struct" type="Duality.Resources.Scene" id="129723834">
  <assetInfo />
  <globalGravity dataType="Struct" type="Duality.Vector2">
    <X dataType="Float">0</X>
    <Y dataType="Float">33</Y>
  </globalGravity>
  <serializeObj dataType="Array" type="Duality.GameObject[]" id="427169525">
    <item dataType="Struct" type="Duality.GameObject" id="4036394049">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="705668291">
        <_items dataType="Array" type="Duality.Component[]" id="1584194086" length="4">
          <item dataType="Struct" type="FNaFMP.Startup.LoadTest" id="1239636250">
            <_x003C_Continue_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Scene]]">
              <contentPath dataType="String">Data\Scenes\MainMenu.Scene.res</contentPath>
            </_x003C_Continue_x003E_k__BackingField>
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">4036394049</gameobj>
          </item>
          <item dataType="Struct" type="FNaFMP.Startup.SplashText" id="3126641738">
            <active dataType="Bool">true</active>
            <display dataType="String">Freddy in space... AGAIN?!</display>
            <font dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Font]]">
              <contentPath dataType="String">Data\Fonts\Consolas16.Font.res</contentPath>
            </font>
            <gameobj dataType="ObjectRef">4036394049</gameobj>
            <lines />
            <texts dataType="Struct" type="System.Collections.Generic.List`1[[System.String]]" id="4003777758">
              <_items dataType="Array" type="System.String[]" id="3970398992" length="16">
                <item dataType="String">When the power goes out, all is not lost. If Freddy is kind to you, he will take longer to do his song!</item>
                <item dataType="String">You can use discord to invite people to lobbies. Just click the + icon when you have the game open and you can send the invite in chat!</item>
                <item dataType="String">Bonnie is a speedy bunny! On average, he has the fastest movetime of all the animatronics!</item>
                <item dataType="String">Did you know that Foxy has the longest average movetime out of all of the animatronics?</item>
                <item dataType="String">As the guard, you don't always have to shut the door instantly. Remember, the animatronics have to wait before being able to attack!</item>
                <item dataType="String">Remember to check the lights to see if Bonnie or Chica are behind the doors!</item>
                <item dataType="String">Make sure not to waste power! Something in the dark might be lurking...</item>
                <item dataType="String">Listen out for Freddy! Every time he moves he will laugh menacingly.</item>
                <item dataType="String">Freddy in space... AGAIN?!</item>
              </_items>
              <_size dataType="Int">9</_size>
            </texts>
          </item>
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3265030328" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3632970665">
            <item dataType="Type" id="2377038350" value="FNaFMP.Startup.LoadTest" />
            <item dataType="Type" id="3523866442" value="FNaFMP.Startup.SplashText" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2131047360">
            <item dataType="ObjectRef">1239636250</item>
            <item dataType="ObjectRef">3126641738</item>
          </values>
        </body>
      </compMap>
      <compTransform />
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1077553035">dls5DAewOEOvvjDZtT3FSA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">GameObject</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3850178089">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3405972139">
        <_items dataType="Array" type="Duality.Component[]" id="1675034870" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="3907455307">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">3850178089</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Camera" id="1101597270">
            <active dataType="Bool">true</active>
            <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
            <farZ dataType="Float">10000</farZ>
            <focusDist dataType="Float">500</focusDist>
            <gameobj dataType="ObjectRef">3850178089</gameobj>
            <nearZ dataType="Float">50</nearZ>
            <priority dataType="Int">0</priority>
            <projection dataType="Enum" type="Duality.Drawing.ProjectionMode" name="Screen" value="2" />
            <renderSetup dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderSetup]]" />
            <renderTarget dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
            <shaderParameters dataType="Struct" type="Duality.Drawing.ShaderParameterCollection" id="2403453242" custom="true">
              <body />
            </shaderParameters>
            <targetRect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">1</H>
              <W dataType="Float">1</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </targetRect>
            <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="All" value="4294967295" />
          </item>
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="351109448" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3933929857">
            <item dataType="Type" id="2040631086" value="Duality.Components.Transform" />
            <item dataType="Type" id="4147198154" value="Duality.Components.Camera" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="1398441312">
            <item dataType="ObjectRef">3907455307</item>
            <item dataType="ObjectRef">1101597270</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3907455307</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3915271891">8Kf+cN0zXEee+X7EdJ/big==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Camera</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3320749047">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3419287733">
        <_items dataType="Array" type="Duality.Component[]" id="3179599606" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="3378026265">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">3320749047</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">1184</X>
              <Y dataType="Float">32</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">1184</X>
              <Y dataType="Float">32</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="494401031">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">3320749047</gameobj>
            <offset dataType="Float">0</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">64</H>
              <W dataType="Float">64</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\fm-spinner.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">0</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="3060945587">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">0.5</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
            <animTime dataType="Float">0</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">15</frameCount>
            <gameobj dataType="ObjectRef">3320749047</gameobj>
            <paused dataType="Bool">false</paused>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="4090762056" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2656300703">
            <item dataType="ObjectRef">2040631086</item>
            <item dataType="Type" id="2948031342" value="Duality.Components.Renderers.SpriteRenderer" />
            <item dataType="Type" id="358709706" value="Duality.Components.Renderers.SpriteAnimator" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="1891698208">
            <item dataType="ObjectRef">3378026265</item>
            <item dataType="ObjectRef">494401031</item>
            <item dataType="ObjectRef">3060945587</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3378026265</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3706996237">6uvsoKe4ZUa7CI5wlJcqQg==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">fm-spinner</name>
      <parent />
      <prefabLink />
    </item>
  </serializeObj>
  <visibilityStrategy dataType="Struct" type="Duality.Components.DefaultRendererVisibilityStrategy" id="2035693768" />
</root>
<!-- XmlFormatterBase Document Separator -->
