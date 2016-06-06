//
//  MDPStoreProductModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPStoreProductModel.h"


#pragma mark StoreProductType
typedef NS_ENUM(NSInteger, MDPStoreProductModelStoreProductType) {
    MDPStoreProductModelStoreProductTypePoints                          = 0,
    MDPStoreProductModelStoreProductTypePack                            = 1,
    MDPStoreProductModelStoreProductTypeVirtualGoods                    = 2,
};


#pragma mark - Interface
@interface MDPStoreProductModel : _MDPStoreProductModel

+ (MDPStoreProductModel *)storeProductWithIdProduct:(NSString *)idProduct managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsStoreProductWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
