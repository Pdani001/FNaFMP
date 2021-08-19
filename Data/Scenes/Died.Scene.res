<root dataType="Struct" type="Duality.Resources.Scene" id="129723834">
  <assetInfo />
  <globalGravity dataType="Struct" type="Duality.Vector2">
    <X dataType="Float">0</X>
    <Y dataType="Float">33</Y>
  </globalGravity>
  <serializeObj dataType="Array" type="Duality.GameObject[]" id="427169525">
    <item dataType="Struct" type="Duality.GameObject" id="238748343">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2970972405">
        <_items dataType="Array" type="Duality.Component[]" id="322018934" length="8">
          <item dataType="Struct" type="Duality.Components.Transform" id="296025561">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">238748343</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Camera" id="1785134820">
            <active dataType="Bool">true</active>
            <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
            <farZ dataType="Float">10000</farZ>
            <focusDist dataType="Float">500</focusDist>
            <gameobj dataType="ObjectRef">238748343</gameobj>
            <nearZ dataType="Float">50</nearZ>
            <priority dataType="Int">0</priority>
            <projection dataType="Enum" type="Duality.Drawing.ProjectionMode" name="Screen" value="2" />
            <renderSetup dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderSetup]]" />
            <renderTarget dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
            <shaderParameters dataType="Struct" type="Duality.Drawing.ShaderParameterCollection" id="1738707488" custom="true">
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
          <item dataType="Struct" type="Duality.Components.VelocityTracker" id="2309882810">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">238748343</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.SoundEmitter" id="2459560226">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">238748343</gameobj>
            <sources dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.SoundEmitter+Source]]" id="2087412950">
              <_items dataType="Array" type="Duality.Components.SoundEmitter+Source[]" id="3929731360" length="16">
                <item dataType="Struct" type="Duality.Components.SoundEmitter+Source" id="4062894044">
                  <looped dataType="Bool">false</looped>
                  <lowpass dataType="Float">1</lowpass>
                  <offset dataType="Struct" type="Duality.Vector3" />
                  <paused dataType="Bool">false</paused>
                  <pitch dataType="Float">1</pitch>
                  <sound dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
                    <contentPath dataType="String">Data\static\static.Sound.res</contentPath>
                  </sound>
                  <volume dataType="Float">1</volume>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </sources>
          </item>
          <item dataType="Struct" type="Duality.Components.SoundListener" id="2271400870">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">238748343</gameobj>
          </item>
          <item dataType="Struct" type="FNaFMP.Utility.SoundManager" id="1735928239">
            <active dataType="Bool">true</active>
            <emitter dataType="ObjectRef">2459560226</emitter>
            <gameobj dataType="ObjectRef">238748343</gameobj>
            <list dataType="ObjectRef">2087412950</list>
            <nonloop dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.SoundEmitter+Source]]" id="3697195215">
              <_items dataType="Array" type="Duality.Components.SoundEmitter+Source[]" id="1697067054" length="0" />
              <_size dataType="Int">0</_size>
            </nonloop>
            <transform dataType="ObjectRef">296025561</transform>
          </item>
        </_items>
        <_size dataType="Int">6</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3434161352" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3731120479">
            <item dataType="Type" id="2229175406" value="Duality.Components.Transform" />
            <item dataType="Type" id="2266994634" value="Duality.Components.Camera" />
            <item dataType="Type" id="1393034334" value="Duality.Components.VelocityTracker" />
            <item dataType="Type" id="619471706" value="Duality.Components.SoundListener" />
            <item dataType="Type" id="3679221774" value="Duality.Components.SoundEmitter" />
            <item dataType="Type" id="2189250922" value="FNaFMP.Utility.SoundManager" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="22285088">
            <item dataType="ObjectRef">296025561</item>
            <item dataType="ObjectRef">1785134820</item>
            <item dataType="ObjectRef">2309882810</item>
            <item dataType="ObjectRef">2271400870</item>
            <item dataType="ObjectRef">2459560226</item>
            <item dataType="ObjectRef">1735928239</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">296025561</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3064763085">ku5dSX8SQE2ztVeVaKO/eQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Camera</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="511413570">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1684115148">
        <_items dataType="Array" type="Duality.Component[]" id="2832363684">
          <item dataType="Struct" type="Duality.Components.Transform" id="568690788">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">511413570</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="1980032850">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">511413570</gameobj>
            <offset dataType="Float">0</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">720</H>
              <W dataType="Float">1280</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\static\static_loop.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">0</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="251610110">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">0.3</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Loop" value="1" />
            <animTime dataType="Float">0</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">8</frameCount>
            <gameobj dataType="ObjectRef">511413570</gameobj>
            <paused dataType="Bool">false</paused>
          </item>
          <item dataType="Struct" type="FNaFMP.Menu.GameOverScreen" id="605073851">
            <_x003C_Lobby_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Scene]]">
              <contentPath dataType="String">Data\Scenes\Lobbies.Scene.res</contentPath>
            </_x003C_Lobby_x003E_k__BackingField>
            <_x003C_StaticSound_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
              <contentPath dataType="String">Data\static\static.Sound.res</contentPath>
            </_x003C_StaticSound_x003E_k__BackingField>
            <active dataType="Bool">true</active>
            <alpha dataType="Int">255</alpha>
            <checkin dataType="Int">495900</checkin>
            <gameobj dataType="ObjectRef">511413570</gameobj>
            <source dataType="ObjectRef">4062894044</source>
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3003035382" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="585764166">
            <item dataType="ObjectRef">2229175406</item>
            <item dataType="Type" id="1311855104" value="Duality.Components.Renderers.SpriteRenderer" />
            <item dataType="Type" id="1666973646" value="Duality.Components.Renderers.SpriteAnimator" />
            <item dataType="Type" id="1449038492" value="FNaFMP.Menu.GameOverScreen" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="1847577530">
            <item dataType="ObjectRef">568690788</item>
            <item dataType="ObjectRef">1980032850</item>
            <item dataType="ObjectRef">251610110</item>
            <item dataType="ObjectRef">605073851</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">568690788</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="80453446">iScXZ1IxeEGMFXwxl+kFbQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">static_loop</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2684125513">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2955180811">
        <_items dataType="Array" type="Duality.Component[]" id="107136630" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="2741402731">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2684125513</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="4152744793">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">2684125513</gameobj>
            <offset dataType="Float">10</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">720</H>
              <W dataType="Float">1280</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\GameOver\gameover_BG.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2144791752" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2545648289">
            <item dataType="ObjectRef">2229175406</item>
            <item dataType="ObjectRef">1311855104</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="3417600800">
            <item dataType="ObjectRef">2741402731</item>
            <item dataType="ObjectRef">4152744793</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2741402731</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1582465331">YkuYeHalOUOm25snDjUqnQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">gameover_BG</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3499568628">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="761152586">
        <_items dataType="Array" type="Duality.Component[]" id="3066709344" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="3556845846">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">3499568628</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">1046</X>
              <Y dataType="Float">660</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">1046</X>
              <Y dataType="Float">660</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="673220612">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">3499568628</gameobj>
            <offset dataType="Float">5</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">27</H>
              <W dataType="Float">206</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\GameOver\gameover_TXT.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2329865370" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3924428080">
            <item dataType="ObjectRef">2229175406</item>
            <item dataType="ObjectRef">1311855104</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="299718254">
            <item dataType="ObjectRef">3556845846</item>
            <item dataType="ObjectRef">673220612</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3556845846</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3405070732">jBwRS+BSeE6PWsauljXdPw==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">gameover_TXT</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="972404225">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="4201937411">
        <_items dataType="Array" type="Duality.Component[]" id="976589094">
          <item dataType="Struct" type="Duality.Components.Transform" id="1029681443">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">972404225</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2441023505">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">972404225</gameobj>
            <offset dataType="Float">0</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">720</H>
              <W dataType="Float">1280</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\blip\blip.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">0</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteAnimator" id="712600765">
            <active dataType="Bool">true</active>
            <animDuration dataType="Float">0.1</animDuration>
            <animLoopMode dataType="Enum" type="Duality.Components.Renderers.SpriteAnimator+LoopMode" name="Once" value="0" />
            <animTime dataType="Float">0</animTime>
            <customFrameSequence />
            <firstFrame dataType="Int">0</firstFrame>
            <frameCount dataType="Int">9</frameCount>
            <gameobj dataType="ObjectRef">972404225</gameobj>
            <paused dataType="Bool">false</paused>
          </item>
          <item dataType="Struct" type="FNaFMP.Menu.GameOverBlip" id="3032974871">
            <_x003C_BlipSound_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Sound]]">
              <contentPath dataType="String">Data\blip\blip.Sound.res</contentPath>
            </_x003C_BlipSound_x003E_k__BackingField>
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">972404225</gameobj>
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3449788344" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3012226409">
            <item dataType="ObjectRef">2229175406</item>
            <item dataType="ObjectRef">1311855104</item>
            <item dataType="ObjectRef">1666973646</item>
            <item dataType="Type" id="2248623374" value="FNaFMP.Menu.GameOverBlip" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="150858432">
            <item dataType="ObjectRef">1029681443</item>
            <item dataType="ObjectRef">2441023505</item>
            <item dataType="ObjectRef">712600765</item>
            <item dataType="ObjectRef">3032974871</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1029681443</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1442360779">nAE7SC3Uu0qWMYEoV7I7Nw==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">blip</name>
      <parent />
      <prefabLink />
    </item>
  </serializeObj>
  <visibilityStrategy dataType="Struct" type="Duality.Components.DefaultRendererVisibilityStrategy" id="2035693768" />
</root>
<!-- XmlFormatterBase Document Separator -->
