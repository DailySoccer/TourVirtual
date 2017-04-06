//
//  MDPMediaContentModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPMediaContentModel.h"

#pragma mark - MediaContentType
typedef NS_ENUM(NSInteger, MDPMediaContentModelMediaContentType ) {
    MDPMediaContentModelMediaContentTypeCardPhoto        = 0,
    MDPMediaContentModelMediaContentTypeProfilePhoto     = 1,
    MDPMediaContentModelMediaContentTypeRegularPhoto     = 2,
    MDPMediaContentModelMediaContentTypeRegularVideo     = 3,
    MDPMediaContentModelMediaContentTypeBiography        = 4,
    MDPMediaContentModelMediaContentTypeShop             = 5,
} ;


#pragma mark - Interface
@interface MDPMediaContentModel : _MDPMediaContentModel

+ (instancetype)insertIfNotExistsMediaContentWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
