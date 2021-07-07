<root dataType="Struct" type="Duality.Resources.Scene" id="129723834">
  <assetInfo />
  <globalGravity dataType="Struct" type="Duality.Vector2">
    <X dataType="Float">0</X>
    <Y dataType="Float">33</Y>
  </globalGravity>
  <serializeObj dataType="Array" type="Duality.GameObject[]" id="427169525">
    <item dataType="Struct" type="Duality.GameObject" id="466599326">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="990979336">
        <_items dataType="Array" type="Duality.Component[]" id="705729388">
          <item dataType="Struct" type="Duality.Components.Transform" id="523876544">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">466599326</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Camera" id="2012985803">
            <active dataType="Bool">true</active>
            <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
            <farZ dataType="Float">10000</farZ>
            <focusDist dataType="Float">500</focusDist>
            <gameobj dataType="ObjectRef">466599326</gameobj>
            <nearZ dataType="Float">50</nearZ>
            <priority dataType="Int">0</priority>
            <projection dataType="Enum" type="Duality.Drawing.ProjectionMode" name="Screen" value="2" />
            <renderSetup dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderSetup]]">
              <contentPath dataType="String">Data\Renderer\NormalSetup.RenderSetup.res</contentPath>
            </renderSetup>
            <renderTarget dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
            <shaderParameters dataType="Struct" type="Duality.Drawing.ShaderParameterCollection" id="2992328263" custom="true">
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
          <item dataType="Struct" type="Duality.Components.VelocityTracker" id="2537733793">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">466599326</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.SoundListener" id="2499251853">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">466599326</gameobj>
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="381329374" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="1265915850">
            <item dataType="Type" id="2229467488" value="Duality.Components.Transform" />
            <item dataType="Type" id="3212399758" value="Duality.Components.Camera" />
            <item dataType="Type" id="3953339260" value="Duality.Components.VelocityTracker" />
            <item dataType="Type" id="1125403410" value="Duality.Components.SoundListener" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2442203290">
            <item dataType="ObjectRef">523876544</item>
            <item dataType="ObjectRef">2012985803</item>
            <item dataType="ObjectRef">2537733793</item>
            <item dataType="ObjectRef">2499251853</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">523876544</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3421037354">2pU1HJmW+0GNGlcbt2eCQg==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Camera</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2446385983">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1075095229">
        <_items dataType="Array" type="Duality.Component[]" id="4215686694" length="8">
          <item dataType="Struct" type="Duality.Components.Transform" id="2503663201">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2446385983</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3915005263">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">2446385983</gameobj>
            <offset dataType="Float">500</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">720</H>
              <W dataType="Float">1280</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Menu\menu BG.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">0</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="AllGroups" value="2147483647" />
          </item>
          <item dataType="Struct" type="FNaFMP.Menu.Background" id="1817012834">
            <active dataType="Bool">true</active>
            <ambience dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
              <contentPath dataType="String">Data\Menu\Music\Ambience.Sound.res</contentPath>
            </ambience>
            <fnaf57 dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
              <contentPath dataType="String">Data\Menu\Music\fis2.Sound.res</contentPath>
            </fnaf57>
            <fnaf57bg dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Menu\menu_rare.Material.res</contentPath>
            </fnaf57bg>
            <gameobj dataType="ObjectRef">2446385983</gameobj>
            <lastOpacity dataType="Int">0</lastOpacity>
            <lastSprite dataType="Int">0</lastSprite>
            <music dataType="Int">0</music>
            <nosound dataType="Bool">false</nosound>
            <render />
            <rnd dataType="Struct" type="System.Random" id="3151447862">
              <inext dataType="Int">0</inext>
              <inextp dataType="Int">21</inextp>
              <SeedArray dataType="Array" type="System.Int32[]" id="3422710624">0, 1650036967, 1965939048, 2100108266, 925481319, 1886858998, 1337531328, 94935044, 671350752, 600633710, 809987133, 252311726, 1413715210, 1306217915, 1787696019, 2114540258, 190890490, 284424033, 1508359455, 1887952808, 574448142, 2106136048, 1525330352, 1926291690, 951580956, 977580850, 2041050340, 345186311, 1463437697, 825039632, 796625608, 1248610386, 307611425, 1998422845, 602224174, 2010196167, 176842234, 488278313, 425101273, 299957338, 1737782158, 317767129, 1908628945, 894142015, 953860817, 1009159912, 681661720, 1297636584, 1038614452, 159539375, 1513456780, 45409024, 1566868609, 319127177, 720852471, 2143574632</SeedArray>
            </rnd>
            <source />
            <themetune dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
              <contentPath dataType="String">Data\Menu\Music\ThemeTune.Sound.res</contentPath>
            </themetune>
          </item>
          <item dataType="Struct" type="FNaFMP.Menu.MenuText" id="3735910080">
            <active dataType="Bool">true</active>
            <font dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Font]]">
              <contentPath dataType="String">Data\Fonts\Consolas16.Font.res</contentPath>
            </font>
            <gameobj dataType="ObjectRef">2446385983</gameobj>
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1827536056" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="1907496919">
            <item dataType="ObjectRef">2229467488</item>
            <item dataType="Type" id="1184914958" value="Duality.Components.Renderers.SpriteRenderer" />
            <item dataType="Type" id="3430358858" value="FNaFMP.Menu.Background" />
            <item dataType="Type" id="608493886" value="FNaFMP.Menu.MenuText" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2502412224">
            <item dataType="ObjectRef">2503663201</item>
            <item dataType="ObjectRef">3915005263</item>
            <item dataType="ObjectRef">1817012834</item>
            <item dataType="ObjectRef">3735910080</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2503663201</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="4107762677">EWK45ehFQEOEtfghcViT3Q==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">menu BG</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2652539583">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1677462589">
        <_items dataType="Array" type="Duality.Component[]" id="2961410086">
          <item dataType="Struct" type="Duality.Components.Transform" id="2709816801">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2652539583</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="4121158863">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">126</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">2652539583</gameobj>
            <offset dataType="Float">150</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">720</H>
              <W dataType="Float">1280</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\static\static_menu.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">2</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="AllGroups" value="2147483647" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="2392736123">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">0.3</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
            <animTime dataType="Float">0.08524992</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">8</frameCount>
            <gameobj dataType="ObjectRef">2652539583</gameobj>
            <paused dataType="Bool">false</paused>
          </item>
          <item dataType="Struct" type="FNaFMP.Utility.GlobalStatic" id="2948134278">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2652539583</gameobj>
            <lastTime dataType="Int">0</lastTime>
            <rnd dataType="Struct" type="System.Random" id="1000335946">
              <inext dataType="Int">0</inext>
              <inextp dataType="Int">21</inextp>
              <SeedArray dataType="Array" type="System.Int32[]" id="1842743648">0, 1777867112, 597105794, 1212852177, 1518466454, 1552692472, 1837204450, 668838307, 756879295, 871175042, 765997803, 1694491500, 1385031281, 1409666561, 952404146, 1404190381, 226611778, 398474273, 1231101470, 2008688010, 2039089523, 1633892335, 67386332, 282887732, 928957839, 1720083131, 796284488, 1019549374, 482546044, 454627987, 1366488664, 140739977, 250567621, 1670526100, 1858801376, 1479697317, 709958842, 177233162, 1654606210, 1966249752, 1198512502, 1143501137, 1109409599, 1033511281, 533215327, 1122694014, 364927807, 1949847371, 2093486719, 1992229086, 133534637, 403458616, 349927243, 1459266426, 751550853, 601978349</SeedArray>
            </rnd>
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2739858104" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="140710231">
            <item dataType="ObjectRef">2229467488</item>
            <item dataType="ObjectRef">1184914958</item>
            <item dataType="Type" id="1684614158" value="Duality.Components.Renderers.SpriteAnimator" />
            <item dataType="Type" id="421299018" value="FNaFMP.Utility.GlobalStatic" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2119305664">
            <item dataType="ObjectRef">2709816801</item>
            <item dataType="ObjectRef">4121158863</item>
            <item dataType="ObjectRef">2392736123</item>
            <item dataType="ObjectRef">2948134278</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2709816801</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="2694561653">eM3HWKkDB0uuCznmGwNAww==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Static</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="272939724">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1493980738">
        <_items dataType="Array" type="Duality.Component[]" id="4120215568">
          <item dataType="Struct" type="Duality.Components.Transform" id="330216942">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">272939724</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.VelocityTracker" id="2344074191">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">272939724</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.SoundEmitter" id="2493751607">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">272939724</gameobj>
            <sources dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.SoundEmitter+Source]]" id="2551971571">
              <_items dataType="Array" type="Duality.Components.SoundEmitter+Source[]" id="106714918" length="0" />
              <_size dataType="Int">0</_size>
            </sources>
          </item>
          <item dataType="Struct" type="FNaFMP.Utility.SoundManager" id="1770119620">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">272939724</gameobj>
            <transform />
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3337856010" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3017426712">
            <item dataType="ObjectRef">2229467488</item>
            <item dataType="ObjectRef">3953339260</item>
            <item dataType="Type" id="1133799980" value="Duality.Components.SoundEmitter" />
            <item dataType="Type" id="1617017782" value="FNaFMP.Utility.SoundManager" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="577017118">
            <item dataType="ObjectRef">330216942</item>
            <item dataType="ObjectRef">2344074191</item>
            <item dataType="ObjectRef">2493751607</item>
            <item dataType="ObjectRef">1770119620</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">330216942</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="2156113476">vUALtIIDCkGcglGtvSS8xw==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">SoundEmitter</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2263628425">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3762397643">
        <_items dataType="Array" type="Duality.Component[]" id="4289900022" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="2320905643">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2263628425</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">68</X>
              <Y dataType="Float">50</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">68</X>
              <Y dataType="Float">50</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3732247705">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">2263628425</gameobj>
            <offset dataType="Float">160</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">148</H>
              <W dataType="Float">443</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Menu\logo.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="AllGroups" value="2147483647" />
          </item>
          <item dataType="Struct" type="FNaFMP.Menu.Logo" id="2405968107">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2263628425</gameobj>
            <render dataType="ObjectRef">3732247705</render>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="821544520" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3095231457">
            <item dataType="ObjectRef">2229467488</item>
            <item dataType="ObjectRef">1184914958</item>
            <item dataType="Type" id="2503166318" value="FNaFMP.Menu.Logo" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2100150304">
            <item dataType="ObjectRef">2320905643</item>
            <item dataType="ObjectRef">3732247705</item>
            <item dataType="ObjectRef">2405968107</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2320905643</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1779807603">muUKccWOH021BPn7x0mSDQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">logo</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="979695321">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1499588987">
        <_items dataType="Array" type="Duality.Component[]" id="1392069462" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="1036972539">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">979695321</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">64</X>
              <Y dataType="Float">281</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">64</X>
              <Y dataType="Float">281</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2448314601">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">127</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">979695321</gameobj>
            <offset dataType="Float">160</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">24</H>
              <W dataType="Float">64</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Menu\Lobby\refresh.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="AllGroups" value="2147483647" />
          </item>
          <item dataType="Struct" type="FNaFMP.Menu.LobbyListText" id="75050219">
            <active dataType="Bool">true</active>
            <ChannelList />
            <DenyReason />
            <Event />
            <font dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Font]]">
              <contentPath dataType="String">Data\Fonts\Consolas16Bold.Font.res</contentPath>
            </font>
            <gameobj dataType="ObjectRef">979695321</gameobj>
            <join dataType="Bool">false</join>
            <lastFrame dataType="Int">0</lastFrame>
            <ListRects />
            <renderer dataType="ObjectRef">2448314601</renderer>
            <scene dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Scene]]">
              <contentPath dataType="String">Data\Scenes\Select.Scene.res</contentPath>
            </scene>
            <settings dataType="Struct" type="FNaFMP.Menu.LobbyListSettings" id="1208032475">
              <columnstep dataType="Int">352</columnstep>
              <maxcolumns dataType="Int">3</maxcolumns>
              <maxrows dataType="Int">10</maxrows>
              <rowstep dataType="Int">32</rowstep>
              <start dataType="Struct" type="Duality.Point2">
                <X dataType="Int">32</X>
                <Y dataType="Int">320</Y>
              </start>
            </settings>
            <transform dataType="ObjectRef">1036972539</transform>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="752883880" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3889554065">
            <item dataType="ObjectRef">2229467488</item>
            <item dataType="ObjectRef">1184914958</item>
            <item dataType="Type" id="3172785646" value="FNaFMP.Menu.LobbyListText" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2848914080">
            <item dataType="ObjectRef">1036972539</item>
            <item dataType="ObjectRef">2448314601</item>
            <item dataType="ObjectRef">75050219</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1036972539</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="4146731779">myxzkrrYl0SewFAbTenwQQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">refresh</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="1725707596">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3128715970">
        <_items dataType="Array" type="Duality.Component[]" id="3578964496" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="1782984814">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">1725707596</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">64</X>
              <Y dataType="Float">249</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">64</X>
              <Y dataType="Float">249</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3194326876">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">1725707596</gameobj>
            <offset dataType="Float">160</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">32</H>
              <W dataType="Float">319</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Menu\Lobby\namebox.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="AllGroups" value="2147483647" />
          </item>
          <item dataType="Struct" type="FNaFMP.Menu.LobbyNameText" id="2727264161">
            <active dataType="Bool">true</active>
            <backspace dataType="Int">4776688</backspace>
            <c dataType="String"></c>
            <extra dataType="String"></extra>
            <font dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Font]]">
              <contentPath dataType="String">Data\Fonts\Consolas16.Font.res</contentPath>
            </font>
            <gameobj dataType="ObjectRef">1725707596</gameobj>
            <input dataType="Int">-1</input>
            <join dataType="Bool">false</join>
            <maxlength dataType="Int">22</maxlength>
            <minlength dataType="Int">3</minlength>
            <Name dataType="String"></Name>
            <renderer dataType="ObjectRef">3194326876</renderer>
            <repeat dataType="Int">-1</repeat>
            <scene dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Scene]]">
              <contentPath dataType="String">Data\Scenes\Select.Scene.res</contentPath>
            </scene>
            <transform dataType="ObjectRef">1782984814</transform>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="138566154" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="827121304">
            <item dataType="ObjectRef">2229467488</item>
            <item dataType="ObjectRef">1184914958</item>
            <item dataType="Type" id="69727788" value="FNaFMP.Menu.LobbyNameText" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="1205784862">
            <item dataType="ObjectRef">1782984814</item>
            <item dataType="ObjectRef">3194326876</item>
            <item dataType="ObjectRef">2727264161</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1782984814</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3898440900">LnTBRHbdrkCOxCMmA4vGKQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">namebox</name>
      <parent />
      <prefabLink />
    </item>
  </serializeObj>
  <visibilityStrategy dataType="Struct" type="Duality.Components.DefaultRendererVisibilityStrategy" id="2035693768" />
</root>
<!-- XmlFormatterBase Document Separator -->
