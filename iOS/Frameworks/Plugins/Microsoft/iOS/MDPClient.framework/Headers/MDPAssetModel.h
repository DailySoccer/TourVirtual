//
//  MDPAssetModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPAssetModel.h"

#pragma mark  - AssetType
typedef NS_ENUM(NSInteger, MDPAssetModelAssetType) {
    MDPAssetModelAssetTypePhoto                 = 0,
    MDPAssetModelAssetTypeVideo                 = 1,
    MDPAssetModelAssetTypeContentTitleImage     = 2,
    MDPAssetModelAssetTypeAudio                 = 3,
    MDPAssetModelAssetTypeBinary                = 4,
    MDPAssetModelAssetTypeModel3D               = 5,
};


#pragma mark - Interface
@interface MDPAssetModel : _MDPAssetModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (MDPAssetModel *)assetInSet:(NSOrderedSet *)assetsSet withType:(int)assetType;

@end
