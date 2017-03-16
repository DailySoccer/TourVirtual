//
//  MDPPartialUpdateItemModel.h
//  MDPClient
//
//  Created by LUIS PAEZ GONZALEZ on 11/3/16.
//  Copyright © 2016 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>


#pragma mark - PartialUpdateOperationType
typedef NS_ENUM(NSInteger, MDPPartialUpdateItemModelPartialUpdateOperationType ) {
    MDPPartialUpdateItemModelPartialUpdateOperationTypeAdd                = 0,
    MDPPartialUpdateItemModelPartialUpdateOperationTypeReplace            = 1,
    MDPPartialUpdateItemModelPartialUpdateOperationTypeRemove             = 2,
    MDPPartialUpdateItemModelPartialUpdateOperationTypeReplacebysearch    = 3,
    MDPPartialUpdateItemModelPartialUpdateOperationTypeRemovebysearch     = 4,
} ;


#pragma mark - Interface
@interface MDPPartialUpdateItemModel : NSObject

- (instancetype)initWithOperation:(MDPPartialUpdateItemModelPartialUpdateOperationType)operationType
                             path:(NSString *)path
                            value:(NSObject *)value
                       searchPath:(NSString *)searchPath
                      searchValue:(NSObject *)searchValue
                       changePath:(NSString *)changePath
                       removePath:(NSString *)removePath;

- (NSDictionary *)partialUpdateItemToDictionary;

@end
