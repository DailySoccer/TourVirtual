//
//  _MDPUserActionHistoryModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPUserActionHistoryModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPUserActionHistoryModelAttributes {
	__unsafe_unretained NSString *actionDate;
	__unsafe_unretained NSString *bodyTemplate;
	__unsafe_unretained NSString *contextData;
	__unsafe_unretained NSString *idAction;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *idUserActionHistory;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *titleTemplate;
} MDPUserActionHistoryModelAttributes;

extern const struct MDPUserActionHistoryModelRelationships {
	__unsafe_unretained NSString *friendTimelineTimeLine;
	__unsafe_unretained NSString *pagedUserActionHistory;
	__unsafe_unretained NSString *tokens;
} MDPUserActionHistoryModelRelationships;

@class MDPFriendTimelineModel;
@class MDPPagedUserActionHistoryModel;
@class MDPActionTokenModel;

@interface _MDPUserActionHistoryModel : NSManagedObject

@property (nonatomic, strong) NSDate* actionDate;

//- (BOOL)validateActionDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* bodyTemplate;

//- (BOOL)validateBodyTemplate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* contextData;

//- (BOOL)validateContextData:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idAction;

//- (BOOL)validateIdAction:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUserActionHistory;

//- (BOOL)validateIdUserActionHistory:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* titleTemplate;

//- (BOOL)validateTitleTemplate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFriendTimelineModel *friendTimelineTimeLine;

//- (BOOL)validateFriendTimelineTimeLine:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *pagedUserActionHistory;

- (NSMutableSet*)pagedUserActionHistorySet;

@property (nonatomic, strong) NSSet *tokens;

- (NSMutableSet*)tokensSet;

@end

@interface _MDPUserActionHistoryModel (PagedUserActionHistoryCoreDataGeneratedAccessors)
- (void)addPagedUserActionHistory:(NSSet*)value_;
- (void)removePagedUserActionHistory:(NSSet*)value_;
- (void)addPagedUserActionHistoryObject:(MDPPagedUserActionHistoryModel*)value_;
- (void)removePagedUserActionHistoryObject:(MDPPagedUserActionHistoryModel*)value_;
@end

@interface _MDPUserActionHistoryModel (TokensCoreDataGeneratedAccessors)
- (void)addTokens:(NSSet*)value_;
- (void)removeTokens:(NSSet*)value_;
- (void)addTokensObject:(MDPActionTokenModel*)value_;
- (void)removeTokensObject:(MDPActionTokenModel*)value_;
@end

@interface _MDPUserActionHistoryModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveActionDate;
- (void)setPrimitiveActionDate:(NSDate*)value;

- (NSString*)primitiveBodyTemplate;
- (void)setPrimitiveBodyTemplate:(NSString*)value;

- (NSString*)primitiveContextData;
- (void)setPrimitiveContextData:(NSString*)value;

- (NSString*)primitiveIdAction;
- (void)setPrimitiveIdAction:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSString*)primitiveIdUserActionHistory;
- (void)setPrimitiveIdUserActionHistory:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveTitleTemplate;
- (void)setPrimitiveTitleTemplate:(NSString*)value;

- (MDPFriendTimelineModel*)primitiveFriendTimelineTimeLine;
- (void)setPrimitiveFriendTimelineTimeLine:(MDPFriendTimelineModel*)value;

- (NSMutableSet*)primitivePagedUserActionHistory;
- (void)setPrimitivePagedUserActionHistory:(NSMutableSet*)value;

- (NSMutableSet*)primitiveTokens;
- (void)setPrimitiveTokens:(NSMutableSet*)value;

@end
