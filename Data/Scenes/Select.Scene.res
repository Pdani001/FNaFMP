<root dataType="Struct" type="Duality.Resources.Scene" id="129723834">
  <assetInfo />
  <globalGravity dataType="Struct" type="Duality.Vector2">
    <X dataType="Float">0</X>
    <Y dataType="Float">33</Y>
  </globalGravity>
  <serializeObj dataType="Array" type="Duality.GameObject[]" id="427169525">
    <item dataType="Struct" type="Duality.GameObject" id="2624407573">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3099804775">
        <_items dataType="Array" type="Duality.Component[]" id="2792213582" length="8">
          <item dataType="Struct" type="Duality.Components.Transform" id="2681684791">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2624407573</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Camera" id="4170794050">
            <active dataType="Bool">true</active>
            <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
            <farZ dataType="Float">10000</farZ>
            <focusDist dataType="Float">500</focusDist>
            <gameobj dataType="ObjectRef">2624407573</gameobj>
            <nearZ dataType="Float">50</nearZ>
            <priority dataType="Int">0</priority>
            <projection dataType="Enum" type="Duality.Drawing.ProjectionMode" name="Screen" value="2" />
            <renderSetup dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderSetup]]">
              <contentPath dataType="String">Data\Renderer\NormalSetup.RenderSetup.res</contentPath>
            </renderSetup>
            <renderTarget dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
            <shaderParameters dataType="Struct" type="Duality.Drawing.ShaderParameterCollection" id="2487295622" custom="true">
              <body />
            </shaderParameters>
            <targetRect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">1</H>
              <W dataType="Float">1</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </targetRect>
            <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
          <item dataType="Struct" type="FNaFMP.Select.BackButton" id="2152914180">
            <active dataType="Bool">true</active>
            <font dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Font]]">
              <contentPath dataType="String">Data\Fonts\Consolas16.Font.res</contentPath>
            </font>
            <gameobj dataType="ObjectRef">2624407573</gameobj>
            <leave dataType="Bool">false</leave>
            <location dataType="Struct" type="Duality.Point2">
              <X dataType="Int">40</X>
              <Y dataType="Int">20</Y>
            </location>
          </item>
          <item dataType="Struct" type="FNaFMP.Select.BGTasks" id="3700243710">
            <_x003C_LoadingScene_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Scene]]">
              <contentPath dataType="String">Data\Scenes\LoadToGame.Scene.res</contentPath>
            </_x003C_LoadingScene_x003E_k__BackingField>
            <_x003C_LobbyScene_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Scene]]">
              <contentPath dataType="String">Data\Scenes\Lobbies.Scene.res</contentPath>
            </_x003C_LobbyScene_x003E_k__BackingField>
            <active dataType="Bool">true</active>
            <countdown dataType="Int">-1</countdown>
            <gameobj dataType="ObjectRef">2624407573</gameobj>
            <leaveing dataType="Bool">false</leaveing>
            <nextcount dataType="Int">-1</nextcount>
            <Players dataType="Struct" type="System.Collections.Generic.List`1[[System.Int32]]" id="3090428434">
              <_items dataType="Array" type="System.Int32[]" id="1547880016"></_items>
              <_size dataType="Int">0</_size>
            </Players>
          </item>
          <item dataType="Struct" type="FNaFMP.Select.CharacterText" id="89456431">
            <active dataType="Bool">true</active>
            <font dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Font]]">
              <contentPath dataType="String">Data\Fonts\Consolas16Bold.Font.res</contentPath>
            </font>
            <gameobj dataType="ObjectRef">2624407573</gameobj>
            <location dataType="Struct" type="Duality.Point2">
              <X dataType="Int">100</X>
              <Y dataType="Int">672</Y>
            </location>
          </item>
        </_items>
        <_size dataType="Int">5</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2482767488" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="1190983245">
            <item dataType="Type" id="522836518" value="Duality.Components.Transform" />
            <item dataType="Type" id="122447546" value="Duality.Components.Camera" />
            <item dataType="Type" id="1076745510" value="FNaFMP.Select.BGTasks" />
            <item dataType="Type" id="2492499898" value="FNaFMP.Select.BackButton" />
            <item dataType="Type" id="1055344678" value="FNaFMP.Select.CharacterText" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="3469361336">
            <item dataType="ObjectRef">2681684791</item>
            <item dataType="ObjectRef">4170794050</item>
            <item dataType="ObjectRef">3700243710</item>
            <item dataType="ObjectRef">2152914180</item>
            <item dataType="ObjectRef">89456431</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2681684791</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1593061927">4QytAILPtUWjz62hgY5sJQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Camera</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="1202609542">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="1343499344">
        <_items dataType="Array" type="Duality.GameObject[]" id="3905687996" length="4">
          <item dataType="Struct" type="Duality.GameObject" id="4278774480">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2655461144">
              <_items dataType="Array" type="Duality.Component[]" id="2417519148" length="4">
                <item dataType="Struct" type="Duality.Components.Transform" id="41084402">
                  <active dataType="Bool">true</active>
                  <angle dataType="Float">0</angle>
                  <angleAbs dataType="Float">0</angleAbs>
                  <gameobj dataType="ObjectRef">4278774480</gameobj>
                  <ignoreParent dataType="Bool">false</ignoreParent>
                  <pos dataType="Struct" type="Duality.Vector3" />
                  <posAbs dataType="Struct" type="Duality.Vector3">
                    <X dataType="Float">288</X>
                    <Y dataType="Float">64</Y>
                    <Z dataType="Float">0</Z>
                  </posAbs>
                  <scale dataType="Float">1</scale>
                  <scaleAbs dataType="Float">1</scaleAbs>
                </item>
                <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="1452426464">
                  <active dataType="Bool">true</active>
                  <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                    <A dataType="Byte">255</A>
                    <B dataType="Byte">255</B>
                    <G dataType="Byte">255</G>
                    <R dataType="Byte">255</R>
                  </colorTint>
                  <customMat />
                  <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                  <gameobj dataType="ObjectRef">4278774480</gameobj>
                  <offset dataType="Float">50</offset>
                  <pixelGrid dataType="Bool">false</pixelGrid>
                  <rect dataType="Struct" type="Duality.Rect">
                    <H dataType="Float">200</H>
                    <W dataType="Float">200</W>
                    <X dataType="Float">0</X>
                    <Y dataType="Float">0</Y>
                  </rect>
                  <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                  <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                    <contentPath dataType="String">Data\Menu\Select\checkmark.Material.res</contentPath>
                  </sharedMat>
                  <spriteIndex dataType="Int">-1</spriteIndex>
                  <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
                </item>
                <item dataType="Struct" type="FNaFMP.Select.Checkmark" id="269202683">
                  <_x003C_Character_x003E_k__BackingField dataType="Enum" type="FNaFMP.Core+Character" name="Bonnie" value="2" />
                  <_x003C_Checked_x003E_k__BackingField dataType="Bool">false</_x003C_Checked_x003E_k__BackingField>
                  <_x003C_Ready_x003E_k__BackingField dataType="Bool">false</_x003C_Ready_x003E_k__BackingField>
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">4278774480</gameobj>
                  <nextclick dataType="UInt">0</nextclick>
                  <peer dataType="Int">-1</peer>
                  <renderer />
                  <Size dataType="Struct" type="Duality.Point2" />
                  <transform />
                </item>
              </_items>
              <_size dataType="Int">3</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2389742878" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="4269469914">
                  <item dataType="ObjectRef">522836518</item>
                  <item dataType="Type" id="1644946688" value="Duality.Components.Renderers.SpriteRenderer" />
                  <item dataType="Type" id="794829262" value="FNaFMP.Select.Checkmark" />
                </keys>
                <values dataType="Array" type="System.Object[]" id="364694202">
                  <item dataType="ObjectRef">41084402</item>
                  <item dataType="ObjectRef">1452426464</item>
                  <item dataType="ObjectRef">269202683</item>
                </values>
              </body>
            </compMap>
            <compTransform dataType="ObjectRef">41084402</compTransform>
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="257926106">aG4YzsDPzE+SFrtELRQTqw==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">check</name>
            <parent dataType="ObjectRef">1202609542</parent>
            <prefabLink />
          </item>
        </_items>
        <_size dataType="Int">1</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3849306478">
        <_items dataType="Array" type="Duality.Component[]" id="1122840866" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="1259886760">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">1202609542</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">288</X>
              <Y dataType="Float">64</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">288</X>
              <Y dataType="Float">64</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2671228822">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">1202609542</gameobj>
            <offset dataType="Float">100</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">200</H>
              <W dataType="Float">200</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Menu\Select\bonnie.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2262477356" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3048071800">
            <item dataType="ObjectRef">522836518</item>
            <item dataType="ObjectRef">1644946688</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="3163392478">
            <item dataType="ObjectRef">1259886760</item>
            <item dataType="ObjectRef">2671228822</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1259886760</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="627388196">hAwha5qemki8AkFzKS9h1Q==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">bonnie</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="588212822">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="1231935744">
        <_items dataType="Array" type="Duality.GameObject[]" id="1372115612" length="4">
          <item dataType="Struct" type="Duality.GameObject" id="3696917073">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1746650605">
              <_items dataType="Array" type="Duality.Component[]" id="2247308006" length="4">
                <item dataType="Struct" type="Duality.Components.Transform" id="3754194291">
                  <active dataType="Bool">true</active>
                  <angle dataType="Float">0</angle>
                  <angleAbs dataType="Float">0</angleAbs>
                  <gameobj dataType="ObjectRef">3696917073</gameobj>
                  <ignoreParent dataType="Bool">false</ignoreParent>
                  <pos dataType="Struct" type="Duality.Vector3" />
                  <posAbs dataType="Struct" type="Duality.Vector3">
                    <X dataType="Float">544</X>
                    <Y dataType="Float">64</Y>
                    <Z dataType="Float">0</Z>
                  </posAbs>
                  <scale dataType="Float">1</scale>
                  <scaleAbs dataType="Float">1</scaleAbs>
                </item>
                <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="870569057">
                  <active dataType="Bool">true</active>
                  <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                    <A dataType="Byte">255</A>
                    <B dataType="Byte">255</B>
                    <G dataType="Byte">255</G>
                    <R dataType="Byte">255</R>
                  </colorTint>
                  <customMat />
                  <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                  <gameobj dataType="ObjectRef">3696917073</gameobj>
                  <offset dataType="Float">50</offset>
                  <pixelGrid dataType="Bool">false</pixelGrid>
                  <rect dataType="Struct" type="Duality.Rect">
                    <H dataType="Float">200</H>
                    <W dataType="Float">200</W>
                    <X dataType="Float">0</X>
                    <Y dataType="Float">0</Y>
                  </rect>
                  <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                  <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                    <contentPath dataType="String">Data\Menu\Select\checkmark.Material.res</contentPath>
                  </sharedMat>
                  <spriteIndex dataType="Int">-1</spriteIndex>
                  <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
                </item>
                <item dataType="Struct" type="FNaFMP.Select.Checkmark" id="3982312572">
                  <_x003C_Character_x003E_k__BackingField dataType="Enum" type="FNaFMP.Core+Character" name="Chica" value="3" />
                  <_x003C_Checked_x003E_k__BackingField dataType="Bool">false</_x003C_Checked_x003E_k__BackingField>
                  <_x003C_Ready_x003E_k__BackingField dataType="Bool">false</_x003C_Ready_x003E_k__BackingField>
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">3696917073</gameobj>
                  <nextclick dataType="UInt">0</nextclick>
                  <peer dataType="Int">-1</peer>
                  <renderer />
                  <Size dataType="Struct" type="Duality.Point2" />
                  <transform />
                </item>
              </_items>
              <_size dataType="Int">3</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1381467384" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="2366743943">
                  <item dataType="ObjectRef">522836518</item>
                  <item dataType="ObjectRef">1644946688</item>
                  <item dataType="ObjectRef">794829262</item>
                </keys>
                <values dataType="Array" type="System.Object[]" id="128851328">
                  <item dataType="ObjectRef">3754194291</item>
                  <item dataType="ObjectRef">870569057</item>
                  <item dataType="ObjectRef">3982312572</item>
                </values>
              </body>
            </compMap>
            <compTransform dataType="ObjectRef">3754194291</compTransform>
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="1970815109">UvkSL+5NhESCE7dvYOhiwQ==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">check</name>
            <parent dataType="ObjectRef">588212822</parent>
            <prefabLink />
          </item>
        </_items>
        <_size dataType="Int">1</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2015599054">
        <_items dataType="Array" type="Duality.Component[]" id="3302141394" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="645490040">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">588212822</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">544</X>
              <Y dataType="Float">64</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">544</X>
              <Y dataType="Float">64</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2056832102">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">588212822</gameobj>
            <offset dataType="Float">100</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">200</H>
              <W dataType="Float">200</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Menu\Select\chica.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2148035484" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="219715768">
            <item dataType="ObjectRef">522836518</item>
            <item dataType="ObjectRef">1644946688</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="3154226398">
            <item dataType="ObjectRef">645490040</item>
            <item dataType="ObjectRef">2056832102</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">645490040</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="2515088612">SKhjQw9kJ0SJ380cwmjt2g==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">chica</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2272508562">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="3970505084">
        <_items dataType="Array" type="Duality.GameObject[]" id="3879937092" length="4">
          <item dataType="Struct" type="Duality.GameObject" id="1111320268">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2127820668">
              <_items dataType="Array" type="Duality.Component[]" id="2307701828" length="4">
                <item dataType="Struct" type="Duality.Components.Transform" id="1168597486">
                  <active dataType="Bool">true</active>
                  <angle dataType="Float">0</angle>
                  <angleAbs dataType="Float">0</angleAbs>
                  <gameobj dataType="ObjectRef">1111320268</gameobj>
                  <ignoreParent dataType="Bool">false</ignoreParent>
                  <pos dataType="Struct" type="Duality.Vector3" />
                  <posAbs dataType="Struct" type="Duality.Vector3">
                    <X dataType="Float">800</X>
                    <Y dataType="Float">64</Y>
                    <Z dataType="Float">0</Z>
                  </posAbs>
                  <scale dataType="Float">1</scale>
                  <scaleAbs dataType="Float">1</scaleAbs>
                </item>
                <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2579939548">
                  <active dataType="Bool">true</active>
                  <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                    <A dataType="Byte">255</A>
                    <B dataType="Byte">255</B>
                    <G dataType="Byte">255</G>
                    <R dataType="Byte">255</R>
                  </colorTint>
                  <customMat />
                  <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                  <gameobj dataType="ObjectRef">1111320268</gameobj>
                  <offset dataType="Float">50</offset>
                  <pixelGrid dataType="Bool">false</pixelGrid>
                  <rect dataType="Struct" type="Duality.Rect">
                    <H dataType="Float">200</H>
                    <W dataType="Float">200</W>
                    <X dataType="Float">0</X>
                    <Y dataType="Float">0</Y>
                  </rect>
                  <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                  <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                    <contentPath dataType="String">Data\Menu\Select\checkmark.Material.res</contentPath>
                  </sharedMat>
                  <spriteIndex dataType="Int">-1</spriteIndex>
                  <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
                </item>
                <item dataType="Struct" type="FNaFMP.Select.Checkmark" id="1396715767">
                  <_x003C_Character_x003E_k__BackingField dataType="Enum" type="FNaFMP.Core+Character" name="Foxy" value="4" />
                  <_x003C_Checked_x003E_k__BackingField dataType="Bool">false</_x003C_Checked_x003E_k__BackingField>
                  <_x003C_Ready_x003E_k__BackingField dataType="Bool">false</_x003C_Ready_x003E_k__BackingField>
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">1111320268</gameobj>
                  <nextclick dataType="UInt">0</nextclick>
                  <peer dataType="Int">-1</peer>
                  <renderer />
                  <Size dataType="Struct" type="Duality.Point2" />
                  <transform />
                </item>
              </_items>
              <_size dataType="Int">3</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1880318102" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="329110486">
                  <item dataType="ObjectRef">522836518</item>
                  <item dataType="ObjectRef">1644946688</item>
                  <item dataType="ObjectRef">794829262</item>
                </keys>
                <values dataType="Array" type="System.Object[]" id="1727118298">
                  <item dataType="ObjectRef">1168597486</item>
                  <item dataType="ObjectRef">2579939548</item>
                  <item dataType="ObjectRef">1396715767</item>
                </values>
              </body>
            </compMap>
            <compTransform dataType="ObjectRef">1168597486</compTransform>
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="2634326262">dYsFUrFnyUyiuvktRal6Jg==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">check</name>
            <parent dataType="ObjectRef">2272508562</parent>
            <prefabLink />
          </item>
        </_items>
        <_size dataType="Int">1</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="251816086">
        <_items dataType="Array" type="Duality.Component[]" id="336003542" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="2329785780">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2272508562</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">800</X>
              <Y dataType="Float">64</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">800</X>
              <Y dataType="Float">64</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3741127842">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">2272508562</gameobj>
            <offset dataType="Float">100</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">200</H>
              <W dataType="Float">200</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Menu\Select\foxy.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1855559976" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="864950360">
            <item dataType="ObjectRef">522836518</item>
            <item dataType="ObjectRef">1644946688</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="1622393758">
            <item dataType="ObjectRef">2329785780</item>
            <item dataType="ObjectRef">3741127842</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2329785780</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="403862276">Y4+KzBOGy0KxApAkvm6k1Q==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">foxy</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="1706482511">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="4142670637">
        <_items dataType="Array" type="Duality.GameObject[]" id="823336550" length="4">
          <item dataType="Struct" type="Duality.GameObject" id="2303674616">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="4194379604">
              <_items dataType="Array" type="Duality.Component[]" id="3281543908" length="4">
                <item dataType="Struct" type="Duality.Components.Transform" id="2360951834">
                  <active dataType="Bool">true</active>
                  <angle dataType="Float">0</angle>
                  <angleAbs dataType="Float">0</angleAbs>
                  <gameobj dataType="ObjectRef">2303674616</gameobj>
                  <ignoreParent dataType="Bool">false</ignoreParent>
                  <pos dataType="Struct" type="Duality.Vector3" />
                  <posAbs dataType="Struct" type="Duality.Vector3">
                    <X dataType="Float">32</X>
                    <Y dataType="Float">64</Y>
                    <Z dataType="Float">0</Z>
                  </posAbs>
                  <scale dataType="Float">1</scale>
                  <scaleAbs dataType="Float">1</scaleAbs>
                </item>
                <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3772293896">
                  <active dataType="Bool">true</active>
                  <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                    <A dataType="Byte">255</A>
                    <B dataType="Byte">255</B>
                    <G dataType="Byte">255</G>
                    <R dataType="Byte">255</R>
                  </colorTint>
                  <customMat />
                  <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                  <gameobj dataType="ObjectRef">2303674616</gameobj>
                  <offset dataType="Float">50</offset>
                  <pixelGrid dataType="Bool">false</pixelGrid>
                  <rect dataType="Struct" type="Duality.Rect">
                    <H dataType="Float">200</H>
                    <W dataType="Float">200</W>
                    <X dataType="Float">0</X>
                    <Y dataType="Float">0</Y>
                  </rect>
                  <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                  <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                    <contentPath dataType="String">Data\Menu\Select\checkmark.Material.res</contentPath>
                  </sharedMat>
                  <spriteIndex dataType="Int">-1</spriteIndex>
                  <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
                </item>
                <item dataType="Struct" type="FNaFMP.Select.Checkmark" id="2589070115">
                  <_x003C_Character_x003E_k__BackingField dataType="Enum" type="FNaFMP.Core+Character" name="Freddy" value="1" />
                  <_x003C_Checked_x003E_k__BackingField dataType="Bool">false</_x003C_Checked_x003E_k__BackingField>
                  <_x003C_Ready_x003E_k__BackingField dataType="Bool">false</_x003C_Ready_x003E_k__BackingField>
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">2303674616</gameobj>
                  <nextclick dataType="UInt">0</nextclick>
                  <peer dataType="Int">-1</peer>
                  <renderer />
                  <Size dataType="Struct" type="Duality.Point2" />
                  <transform />
                </item>
              </_items>
              <_size dataType="Int">3</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1505959350" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="2199554302">
                  <item dataType="ObjectRef">522836518</item>
                  <item dataType="ObjectRef">1644946688</item>
                  <item dataType="ObjectRef">794829262</item>
                </keys>
                <values dataType="Array" type="System.Object[]" id="335823754">
                  <item dataType="ObjectRef">2360951834</item>
                  <item dataType="ObjectRef">3772293896</item>
                  <item dataType="ObjectRef">2589070115</item>
                </values>
              </body>
            </compMap>
            <compTransform dataType="ObjectRef">2360951834</compTransform>
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="1604996750">goRPjTu+E02t5O6kZTNpyQ==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">check</name>
            <parent dataType="ObjectRef">1706482511</parent>
            <prefabLink />
          </item>
        </_items>
        <_size dataType="Int">1</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1769280120">
        <_items dataType="Array" type="Duality.Component[]" id="1513386055" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="1763759729">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">1706482511</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">32</X>
              <Y dataType="Float">64</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">32</X>
              <Y dataType="Float">64</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3175101791">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">1706482511</gameobj>
            <offset dataType="Float">100</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">200</H>
              <W dataType="Float">200</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Menu\Select\freddy.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2926426951" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="769782868">
            <item dataType="ObjectRef">522836518</item>
            <item dataType="ObjectRef">1644946688</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="448017334">
            <item dataType="ObjectRef">1763759729</item>
            <item dataType="ObjectRef">3175101791</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1763759729</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1257662320">aItSDjx910q7LquQDfXZxw==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">freddy</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2865842017">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="355828899">
        <_items dataType="Array" type="Duality.GameObject[]" id="2432918886" length="4">
          <item dataType="Struct" type="Duality.GameObject" id="2389939939">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="687552243">
              <_items dataType="Array" type="Duality.Component[]" id="2100061990" length="4">
                <item dataType="Struct" type="Duality.Components.Transform" id="2447217157">
                  <active dataType="Bool">true</active>
                  <angle dataType="Float">0</angle>
                  <angleAbs dataType="Float">0</angleAbs>
                  <gameobj dataType="ObjectRef">2389939939</gameobj>
                  <ignoreParent dataType="Bool">false</ignoreParent>
                  <pos dataType="Struct" type="Duality.Vector3" />
                  <posAbs dataType="Struct" type="Duality.Vector3">
                    <X dataType="Float">1056</X>
                    <Y dataType="Float">64</Y>
                    <Z dataType="Float">0</Z>
                  </posAbs>
                  <scale dataType="Float">1</scale>
                  <scaleAbs dataType="Float">1</scaleAbs>
                </item>
                <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3858559219">
                  <active dataType="Bool">true</active>
                  <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                    <A dataType="Byte">255</A>
                    <B dataType="Byte">255</B>
                    <G dataType="Byte">255</G>
                    <R dataType="Byte">255</R>
                  </colorTint>
                  <customMat />
                  <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                  <gameobj dataType="ObjectRef">2389939939</gameobj>
                  <offset dataType="Float">50</offset>
                  <pixelGrid dataType="Bool">false</pixelGrid>
                  <rect dataType="Struct" type="Duality.Rect">
                    <H dataType="Float">200</H>
                    <W dataType="Float">200</W>
                    <X dataType="Float">0</X>
                    <Y dataType="Float">0</Y>
                  </rect>
                  <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                  <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                    <contentPath dataType="String">Data\Menu\Select\checkmark.Material.res</contentPath>
                  </sharedMat>
                  <spriteIndex dataType="Int">-1</spriteIndex>
                  <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
                </item>
                <item dataType="Struct" type="FNaFMP.Select.Checkmark" id="2675335438">
                  <_x003C_Character_x003E_k__BackingField dataType="Enum" type="FNaFMP.Core+Character" name="Guard" value="5" />
                  <_x003C_Checked_x003E_k__BackingField dataType="Bool">false</_x003C_Checked_x003E_k__BackingField>
                  <_x003C_Ready_x003E_k__BackingField dataType="Bool">false</_x003C_Ready_x003E_k__BackingField>
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">2389939939</gameobj>
                  <nextclick dataType="UInt">0</nextclick>
                  <peer dataType="Int">-1</peer>
                  <renderer />
                  <Size dataType="Struct" type="Duality.Point2" />
                  <transform />
                </item>
              </_items>
              <_size dataType="Int">3</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1238098360" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="1140623769">
                  <item dataType="ObjectRef">522836518</item>
                  <item dataType="ObjectRef">1644946688</item>
                  <item dataType="ObjectRef">794829262</item>
                </keys>
                <values dataType="Array" type="System.Object[]" id="1834811008">
                  <item dataType="ObjectRef">2447217157</item>
                  <item dataType="ObjectRef">3858559219</item>
                  <item dataType="ObjectRef">2675335438</item>
                </values>
              </body>
            </compMap>
            <compTransform dataType="ObjectRef">2447217157</compTransform>
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="4109373659">5lngyeR+NEO0nzqT+3jtKg==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">check</name>
            <parent dataType="ObjectRef">2865842017</parent>
            <prefabLink />
          </item>
        </_items>
        <_size dataType="Int">1</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2610827640">
        <_items dataType="Array" type="Duality.Component[]" id="1006942153" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="2923119235">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2865842017</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">1056</X>
              <Y dataType="Float">64</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">1056</X>
              <Y dataType="Float">64</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="39494001">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">2865842017</gameobj>
            <offset dataType="Float">100</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">200</H>
              <W dataType="Float">200</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Menu\Select\guard.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="882099977" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="1089130388">
            <item dataType="ObjectRef">522836518</item>
            <item dataType="ObjectRef">1644946688</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="344910902">
            <item dataType="ObjectRef">2923119235</item>
            <item dataType="ObjectRef">39494001</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2923119235</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3671655984">Jjc2wAQKM0iRRNhmbH5adg==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">guard</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2658511931">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3385623881">
        <_items dataType="Array" type="Duality.Component[]" id="1212205966" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="2715789149">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2658511931</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">1020</X>
              <Y dataType="Float">600</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">1020</X>
              <Y dataType="Float">600</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="4127131211">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">2658511931</gameobj>
            <offset dataType="Float">0</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">58</H>
              <W dataType="Float">186</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Menu\Select\READY.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
          <item dataType="Struct" type="FNaFMP.Select.ReadyButton" id="2809246718">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2658511931</gameobj>
            <nextclick dataType="UInt">0</nextclick>
            <renderer />
            <Size dataType="Struct" type="Duality.Point2" />
            <transform />
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1651481408" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2186833667">
            <item dataType="ObjectRef">522836518</item>
            <item dataType="ObjectRef">1644946688</item>
            <item dataType="Type" id="2070301990" value="FNaFMP.Select.ReadyButton" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="3274548152">
            <item dataType="ObjectRef">2715789149</item>
            <item dataType="ObjectRef">4127131211</item>
            <item dataType="ObjectRef">2809246718</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2715789149</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="2478862377">lT8LoKJxc0eyMrXEeV3sFA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">READY</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="1944652500">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2795646698">
        <_items dataType="Array" type="Duality.Component[]" id="3480228128" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="2001929718">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">1944652500</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">100</X>
              <Y dataType="Float">630</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">100</X>
              <Y dataType="Float">630</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3413271780">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">1944652500</gameobj>
            <offset dataType="Float">0</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">32</H>
              <W dataType="Float">590</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\Menu\Select\msgbox.Material.res</contentPath>
            </sharedMat>
            <spriteIndex dataType="Int">-1</spriteIndex>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
          <item dataType="Struct" type="FNaFMP.Select.ChatBox" id="3576079867">
            <active dataType="Bool">true</active>
            <backspace dataType="Int">-1</backspace>
            <c dataType="String"></c>
            <chatpos dataType="Struct" type="Duality.Point2">
              <X dataType="Int">100</X>
              <Y dataType="Int">315</Y>
            </chatpos>
            <cutlength dataType="Int">46</cutlength>
            <extra dataType="String"></extra>
            <font dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Font]]">
              <contentPath dataType="String">Data\Fonts\Consolas16.Font.res</contentPath>
            </font>
            <gameobj dataType="ObjectRef">1944652500</gameobj>
            <input dataType="Int">-1</input>
            <lines dataType="UInt">12</lines>
            <maxlength dataType="Int">128</maxlength>
            <nextchat dataType="Int">-1</nextchat>
            <renderer dataType="ObjectRef">3413271780</renderer>
            <repeat dataType="Int">-1</repeat>
            <Text dataType="String"></Text>
            <transform dataType="ObjectRef">2001929718</transform>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1801303002" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="760747984">
            <item dataType="ObjectRef">522836518</item>
            <item dataType="ObjectRef">1644946688</item>
            <item dataType="Type" id="3458198204" value="FNaFMP.Select.ChatBox" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="965108334">
            <item dataType="ObjectRef">2001929718</item>
            <item dataType="ObjectRef">3413271780</item>
            <item dataType="ObjectRef">3576079867</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2001929718</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1379923884">sRv0fRcqhUuHsapEh83vlQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">msgbox</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="1903651373">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2338922271">
        <_items dataType="Array" type="Duality.Component[]" id="2749388654">
          <item dataType="Struct" type="Duality.Components.Transform" id="1960928591">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">1903651373</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.VelocityTracker" id="3974785840">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1903651373</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.SoundEmitter" id="4124463256">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1903651373</gameobj>
            <sources dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.SoundEmitter+Source]]" id="3427744196">
              <_items dataType="Array" type="Duality.Components.SoundEmitter+Source[]" id="1326881092" length="0" />
              <_size dataType="Int">0</_size>
            </sources>
          </item>
          <item dataType="Struct" type="FNaFMP.Utility.SoundManager" id="3400831269">
            <active dataType="Bool">true</active>
            <emitter dataType="ObjectRef">4124463256</emitter>
            <gameobj dataType="ObjectRef">1903651373</gameobj>
            <list dataType="ObjectRef">3427744196</list>
            <nonloop dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.SoundEmitter+Source]]" id="3916387205">
              <_items dataType="ObjectRef">1326881092</_items>
              <_size dataType="Int">0</_size>
            </nonloop>
            <transform dataType="ObjectRef">1960928591</transform>
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3668789792" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2992597653">
            <item dataType="ObjectRef">522836518</item>
            <item dataType="Type" id="712393846" value="Duality.Components.VelocityTracker" />
            <item dataType="Type" id="1062334746" value="Duality.Components.SoundEmitter" />
            <item dataType="Type" id="605175702" value="FNaFMP.Utility.SoundManager" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="1107928776">
            <item dataType="ObjectRef">1960928591</item>
            <item dataType="ObjectRef">3974785840</item>
            <item dataType="ObjectRef">4124463256</item>
            <item dataType="ObjectRef">3400831269</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1960928591</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1526456735">ann4hzLOjESpoci/z/ZT5g==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Sound</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="ObjectRef">4278774480</item>
    <item dataType="ObjectRef">3696917073</item>
    <item dataType="ObjectRef">1111320268</item>
    <item dataType="ObjectRef">2303674616</item>
    <item dataType="ObjectRef">2389939939</item>
  </serializeObj>
  <visibilityStrategy dataType="Struct" type="Duality.Components.DefaultRendererVisibilityStrategy" id="2035693768" />
</root>
<!-- XmlFormatterBase Document Separator -->
