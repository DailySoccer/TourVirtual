//
//  FixApp.cpp
//  Unity-iPhone
//
//  Created by Ximo on 16/5/17.
//  https://github.com/googlevr/gvr-unity-sdk/issues/130
//
//

#include <vector>
namespace gvr {
    class VrApp;
    VrApp* CreateMainApp__EXPECTED_EXACTLY_ONE_VR_MAIN_APP_STATEMENT__(const std::vector<std::string>&) { return nullptr;
    }
}
