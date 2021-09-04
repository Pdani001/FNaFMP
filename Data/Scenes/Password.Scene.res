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
        <_items dataType="Array" type="Duality.Component[]" id="705729388" length="8">
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
          <item dataType="Struct" type="FNaFMP.Menu.MenuBackButton" id="3630524903">
            <_x003C_BackScene_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Scene]]">
              <contentPath dataType="String">Data\Scenes\Lobbies.Scene.res</contentPath>
            </_x003C_BackScene_x003E_k__BackingField>
            <active dataType="Bool">true</active>
            <font dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Font]]">
              <contentPath dataType="String">Data\Fonts\Consolas16.Font.res</contentPath>
            </font>
            <gameobj dataType="ObjectRef">466599326</gameobj>
            <location dataType="Struct" type="Duality.Point2">
              <X dataType="Int">40</X>
              <Y dataType="Int">20</Y>
            </location>
          </item>
        </_items>
        <_size dataType="Int">5</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="381329374" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="1265915850">
            <item dataType="Type" id="2229467488" value="Duality.Components.Transform" />
            <item dataType="Type" id="3212399758" value="Duality.Components.Camera" />
            <item dataType="Type" id="3953339260" value="Duality.Components.VelocityTracker" />
            <item dataType="Type" id="1125403410" value="Duality.Components.SoundListener" />
            <item dataType="Type" id="4025423640" value="FNaFMP.Menu.MenuBackButton" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2442203290">
            <item dataType="ObjectRef">523876544</item>
            <item dataType="ObjectRef">2012985803</item>
            <item dataType="ObjectRef">2537733793</item>
            <item dataType="ObjectRef">2499251853</item>
            <item dataType="ObjectRef">3630524903</item>
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
            <emitter dataType="ObjectRef">2493751607</emitter>
            <gameobj dataType="ObjectRef">272939724</gameobj>
            <list dataType="ObjectRef">2551971571</list>
            <nonloop dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.SoundEmitter+Source]]" id="2137544236">
              <_items dataType="Array" type="Duality.Components.SoundEmitter+Source[]" id="118803684" length="0" />
              <_size dataType="Int">0</_size>
            </nonloop>
            <transform dataType="ObjectRef">330216942</transform>
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
    <item dataType="Struct" type="Duality.GameObject" id="991783897">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="2534058107">
        <_items dataType="Array" type="Duality.GameObject[]" id="113150294" length="4" />
        <_size dataType="Int">0</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="931435176">
        <_items dataType="Array" type="Duality.Component[]" id="796488081" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="1049061115">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">991783897</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">480</X>
              <Y dataType="Float">342</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">480</X>
              <Y dataType="Float">342</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2460403177">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">991783897</gameobj>
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
          <item dataType="Struct" type="FNaFMP.Menu.PasswordMenu" id="940660332">
            <_x003C_LobbyScene_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Scene]]">
              <contentPath dataType="String">Data\Scenes\Lobbies.Scene.res</contentPath>
            </_x003C_LobbyScene_x003E_k__BackingField>
            <_x003C_SelectScene_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Scene]]">
              <contentPath dataType="String">Data\Scenes\Select.Scene.res</contentPath>
            </_x003C_SelectScene_x003E_k__BackingField>
            <active dataType="Bool">true</active>
            <backspace dataType="Int">-1</backspace>
            <c dataType="String"></c>
            <counter dataType="Long">-1</counter>
            <extra dataType="String"></extra>
            <font dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Font]]">
              <contentPath dataType="String">Data\Fonts\Consolas16.Font.res</contentPath>
            </font>
            <gameobj dataType="ObjectRef">991783897</gameobj>
            <input dataType="Int">-1</input>
            <Name dataType="String"></Name>
            <renderer dataType="ObjectRef">2460403177</renderer>
            <repeat dataType="Int">-1</repeat>
            <Sending dataType="Bool">false</Sending>
            <transform dataType="ObjectRef">1049061115</transform>
            <wait dataType="String">[.  ]</wait>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1035283313" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="528606052">
            <item dataType="ObjectRef">2229467488</item>
            <item dataType="Type" id="1386247108" value="Duality.Components.Renderers.SpriteRenderer" />
            <item dataType="Type" id="4220650902" value="FNaFMP.Menu.PasswordMenu" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="3270330902">
            <item dataType="ObjectRef">1049061115</item>
            <item dataType="ObjectRef">2460403177</item>
            <item dataType="ObjectRef">940660332</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1049061115</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3615498336">5EdekNtaJke6ShQqDOGxng==</data>
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
