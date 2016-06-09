//
//  _MDPContentLinkModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPContentLinkModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPContentLinkModelAttributes {
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *order;
	__unsafe_unretained NSString *text;
	__unsafe_unretained NSString *url;
} MDPContentLinkModelAttributes;

extern const struct MDPContentLinkModelRelationships {
	__unsafe_unretained NSString *compactContent;
	__unsafe_unretained NSString *contentLinks;
	__unsafe_unretained NSString *contentRelatedNews;
} MDPContentLinkModelRelationships;

@class MDPCompactContentModel;
@class MDPContentModel;
@class MDPContentModel;

@interface _MDPContentLinkModel : NSManagedObject

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* order;

@property (atomic) uint64_t orderValue;
- (uint64_t)orderValue;
- (void)setOrderValue:(uint64_t)value_;

//- (BOOL)validateOrder:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* text;

//- (BOOL)validateText:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* url;

//- (BOOL)validateUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *compactContent;

- (NSMutableSet*)compactContentSet;

@property (nonatomic, strong) NSSet *contentLinks;

- (NSMutableSet*)contentLinksSet;

@property (nonatomic, strong) NSSet *contentRelatedNews;

- (NSMutableSet*)contentRelatedNewsSet;

@end

@interface _MDPContentLinkModel (CompactContentCoreDataGeneratedAccessors)
- (void)addCompactContent:(NSSet*)value_;
- (void)removeCompactContent:(NSSet*)value_;
- (void)addCompactContentObject:(MDPCompactContentModel*)value_;
- (void)removeCompactContentObject:(MDPCompactContentModel*)value_;
@end

@interface _MDPContentLinkModel (ContentLinksCoreDataGeneratedAccessors)
- (void)addContentLinks:(NSSet*)value_;
- (void)removeContentLinks:(NSSet*)value_;
- (void)addContentLinksObject:(MDPContentModel*)value_;
- (void)removeContentLinksObject:(MDPContentModel*)value_;
@end

@interface _MDPContentLinkModel (ContentRelatedNewsCoreDataGeneratedAccessors)
- (void)addContentRelatedNews:(NSSet*)value_;
- (void)removeContentRelatedNews:(NSSet*)value_;
- (void)addContentRelatedNewsObject:(MDPContentModel*)value_;
- (void)removeContentRelatedNewsObject:(MDPContentModel*)value_;
@end

@interface _MDPContentLinkModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveOrder;
- (void)setPrimitiveOrder:(NSNumber*)value;

- (uint64_t)primitiveOrderValue;
- (void)setPrimitiveOrderValue:(uint64_t)value_;

- (NSString*)primitiveText;
- (void)setPrimitiveText:(NSString*)value;

- (NSString*)primitiveUrl;
- (void)setPrimitiveUrl:(NSString*)value;

- (NSMutableSet*)primitiveCompactContent;
- (void)setPrimitiveCompactContent:(NSMutableSet*)value;

- (NSMutableSet*)primitiveContentLinks;
- (void)setPrimitiveContentLinks:(NSMutableSet*)value;

- (NSMutableSet*)primitiveContentRelatedNews;
- (void)setPrimitiveContentRelatedNews:(NSMutableSet*)value;

@end
